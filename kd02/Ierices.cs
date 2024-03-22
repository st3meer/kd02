
using System.Dynamic;

abstract class Ierices{ 
    protected string modelName; //modelis
    protected double price; //cena

    protected bool isOn; //ieslets vai izslegs

    abstract public void turnOn(); //abstracta metod ieslegt
    abstract public void turnOff(); //abstracta metod izslegt

    virtual public void printInfo(){ //virtuala metode, kas izvada informaciju par ierici
        Console.WriteLine("Model: " + modelName);
        Console.WriteLine("Price: " + price);
    }
}

class Dators : Ierices{

    private string user;
    private int monitorSize;

    private Server connectedServer; //savienotais serveris


    public Dators(string modelName, double price, string user, int monitorSize){ //konstruktors
        this.modelName = modelName;
        this.price = price;
        this.user = user;
        this.monitorSize = monitorSize;
    }

    public string getUser(){ //atgriezt datora lietotaju
        return user;
    }

    public override void turnOn(){ //ieslegt datoru metode
        Console.WriteLine("Dators ir ieslegs");
        isOn = true;
    }

    public override void turnOff(){ //izslegt datoru metode
        Console.WriteLine("Dators ir izslegs");
        isOn = false;
    }

    public override void printInfo(){ //izvadit informaciju par datoru
        base.printInfo();
        Console.WriteLine("User: " + user);
        Console.WriteLine("Monitor size: " + monitorSize);
        if (connectedServer != null){ //ja ir savienots ar serveri
            Console.WriteLine("Connected server: " + connectedServer.getServerName());
        } else {
            Console.WriteLine("Not connected to server");
        }
    }

    public void connectToServer(Server server){ //savienot datoru ar serveri
        Console.WriteLine("Gribat savienot datoru ar serveri?"); //prasam lietotajam
        if (Console.ReadLine() == "Y"){ //parbaude
            bool isonserver = server.getIsOnServer(); //parbaude, vai serveris ir ieslegs
            if (isonserver){ //parbaude, vai serveris ir ieslegs
                connectedServer = server; //savienojam
            }
            Console.WriteLine("Dators ir savienots ar serveri " + connectedServer.getServerName());
            server.connectToComputer(this); //savienojam serveri ar datoru
        }
    }
    public void disconnect (){ //atvienot datoru no servera
        connectedServer = null; //atvienojam
        Console.WriteLine("Dators ir atvienots no servera");
    }
}

class Server : Ierices{
    private string serverName;
    private int ramSize;

    private List<Dators> connectedComputer = new List<Dators>(); //savienotie datori

    public Server(string modelName, double price, string serverName, int ramSize){ //konstruktors
        this.modelName = modelName;
        this.price = price;
        this.serverName = serverName;
        this.ramSize = ramSize;
    }

    public string getServerName(){ //atgriezt servera nosaukumu
        return serverName;
    }

    public bool getIsOnServer(){ //atgriezt vai serveris ir ieslegs
        return isOn;
    }
    
    public override void turnOn(){ //ieslegt serveri
        Console.WriteLine("Gribat ieslegt serveri?");
        if (Console.ReadLine() == "Y") Console.WriteLine("Serveris ir ieslegs"); //parbaude
        isOn = true;
    }

    public override void turnOff(){ //izslegt serveri
        Console.WriteLine("Gribat izslegt serveri? Visi savienojumi tiks beigti.");
        if (Console.ReadLine() == "Y"){  //parbaude
            Console.WriteLine("Serveris ir izslegs");
            isOn = false;
            foreach (Dators dators in connectedComputer){ //atvienojam visus datorus
                dators.disconnect();
            }
            connectedComputer.Clear(); //iztuksojam sarakstu

        }
    }

    public override void printInfo(){ //izvadit informaciju par serveri
        base.printInfo();
        Console.WriteLine("Server name: " + serverName);
        Console.WriteLine("RAM size: " + ramSize);
        if (connectedComputer.Count == 0){ //ja nav savienotu datoru
            Console.WriteLine("No connected computers");
        } else {
        foreach (Dators dators in connectedComputer){ //izvadam visus savienotos datorus
            Console.WriteLine("Connected computer: " + dators);
        }
        }
    }

    public void connectToComputer(Dators dators){ //savienot serveri ar datoru
        connectedComputer.Add(dators); //savienojam
        Console.WriteLine("Serveris ir savienots ar datoru " + dators);
    }
}