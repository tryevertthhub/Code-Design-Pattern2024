class Implementation {
    public:
    virtual ~Implementation() {}
    virtual std::string OperationImplementation() const  = 0;
};

class ConcreteImplementationA: public Implementation {
    public:
    std::string OperationImplementation() const override {
        return "ConcreteImplementationA: Here's the result on the platform A.\n";
    }
};

class ConcreteImplementationB: public Implementation {
    public:
    std::string OperationImplementation() const override {
       return "ConcreteImplementationB: Here's the result on the platform B.\n";    
    }
};

class Abstraction {
    protected:
    Implementation *implementation_;
    public: 
    Abstraction(Implementation *implementation): implementation_(implementation) {}

    virtual ~Abstraction() {}

    virtual std::string Operation() const {
      return "Abstraction: Base operation with:\n" +
           this->implementation_->OperationImplementation();  
    }
};

class ExtendedAbstraction: public Abstraction {
    public:
    ExtendedAbstraction(Implementation *implementation): Abstraction(implementation) {}

    std::string Operation() const override {
         return "ExtendedAbstraction: Extended operation with:\n" +
           this->implementation_->OperationImplementation();
    }
}

void ClientCode(const Abstraction &abstraction) {
    std::cout << abstraction.Operation();
}

int int main(int argc, char const *argv[])
{
    
    Implementation *implementation = new ConcreteImplementationA;
    Abstraction *abstraction = new Abstraction(implementation);
    ClientCode(*abstraction);
    std::cout << std::endl;

    delete implementation;
    delete abstraction;

    implementation = new ConcreteImplementationB;
    abstraction = new ExtendedAbstraction(implementation);
    ClientCode(*abstraction);
    delete abstraction;
    return 0;
}
