class Product1{
    public:
    std::vector<std::string> parts_;
    void ListParts()const{
        std::cout << "Product parts: ";
        for (size_t i=0;i<parts_.size();i++){
            if(parts_[i]== parts_.back()){
                std::cout << parts_[i];
            }else{
                std::cout << parts_[i] << ", ";
            }
        }
        std::cout << "\n\n"; 
    }
};

class Builder {
    public:
    virtual ~Builder() {}
    virtual void ProducePartA() const = 0;
    virtual void ProducePartB() const = 0;
    virtual void ProducePartC() const = 0;
}

class ConcreteBuilder1: public Builder {
    private:
    Product1 *product;

    public:
    ConcreteBuilder1() {
        this -> Reset();
    }

    ~ConcreteBuilder1() {
        delete product;
    }

    void Reset() {
        this -> product = new Product1();
    }

    void ProducePartA() const override {
        this -> product -> parts_.push_back("PartA1");
    }

    void ProducePartB() const override {
        this -> product -> parts_.push_back("PartB1");
    }

    void ProducePartC() const override {
        this->product->parts_.push_back("PartC1");
    }

    Product1 *GetProduct() {
        Product1 *result = this -> product;
        this -> Reset();
        return result;
    }
};

class Decorator {
    /*
    @var Builder
    */
   private:
   Builder* builder;

   public:
   void set_builder(Builder *builder) {
    this -> builder = builder;
   }

   void BuildMinimalViableProduct() {
    this -> builder -> ProducePartA();
   }

   void BuildFullFeaturedProduct() {
    this -> builder -> ProducePartA();
    this -> builder -> ProducePartB();
    this -> builder -> ProducePartC();
   }
};

void ClientCode(Decorator &director)
{
    ConcreteBuilder1 *builder = new ConcreteBuilder1();
    director.set_builder(builder);
    std::cout << "Standard basic product: \n";
    director.BuildFullFeaturedProduct();

    Product1 *p = builder -> GetProduct();
    p -> ListParts();
    delete p;

    std::cout << "Standard full featured product:\n";
    director.BuildFullFeaturedProduct();
    p = builder ->GetProduct();
    p -> ListParts();
    delete p;
}