#include <iostream>

class Subject {
    public:
    virtual void Request() const = 0;
};

class RealSubject: public Subject {
    public:
    void Request() const override {
        std::count << "RealSubject: Handling request.\n";
    }
};

class Proxy: public Subject {
    // @var RealSubject
    private:
    RealSubject *real_subject_;
    bool CheckAccess() const {
         std::cout << "Proxy: Checking access prior to firing a real request.\n";
         return true;
    }
    void LogAccess() const {
        std::cout << "Proxy: Logging the time of request.\n";
    }

    public:
    Proxy(RealSubject *real_subject): real_subject_(new RealSubject(*real_subject)){}

    ~Proxy() {
        delete real_subject_;
    }

    void Request() const override {
        if (this -> CheckAccess()) {
            this -> real_subject_ -> Request();
            this -> LogAccess();
        }
    }
};

void ClientCode(const Subject &subject) {
    subject.Request();
}

int main() {
    std::cout << "Client: Executing the client code with a real subject:\n";
    RealSubject *real_subject = new RealSubject();
    ClientCode(*real_subject);
    std::cout << "\n";
    std::cout << "Client: Executing the same client code with a proxy:\n";

    Proxy *proxy = new Proxy(real_subject);
    ClientCode(*proxy);

    delete real_subject;
    delete proxy;
    return 0;
}