class Main{
    public static void main(string[] args){
        Dators dators1 = new Dators("Dell", 1000, "Janis", 17);
        Dators dators2 = new Dators("Apple", 2000, "Sonya", 15);
        Server server1 = new Server("HP", 2000, "Serveris", 64);
        
        dators1.printInfo();
        dators2.printInfo();
        server1.printInfo();
        
        dators1.turnOn();
        dators2.turnOn();
        server1.turnOn();
        
        dators1.printInfo();
        dators1.printInfo();
        server1.printInfo();
        
        dators1.connectToServer(server1);
        dators2.connectToServer(server1);

        dators1.printInfo();
        dators2.printInfo();

        dators1.disconnect();

        dators1.printInfo();
        dators2.printInfo();

        server1.turnOff();

        dators1.printInfo();
        dators2.printInfo();
    }
}