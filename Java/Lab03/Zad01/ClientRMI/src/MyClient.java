public class MyClient {
    public static void main(String[] args) {
        double wynik;
        CalcObject zObiekt;
        CalcObject2 zObiekt2;
        ResultType wynik2;
        InputType inObj;
        
        if(args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }
        
        String adres = args[0];


        inObj = new InputType();
        inObj.x1 = 2.2;
        inObj.x2 = 3.3;
        inObj.operation = "add";

        try {
            zObiekt = (CalcObject) java.rmi.Naming.lookup(adres);
            //tu cooos
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do "+adres);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do "+adres+" jest pobrana.");
        
        try {
            wynik = zObiekt.calculate(1.1, 2.2);
        } catch (Exception e) {
            System.out.println("Błąd zdalnego wywołania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik = "+wynik);
        return;
    }
}
