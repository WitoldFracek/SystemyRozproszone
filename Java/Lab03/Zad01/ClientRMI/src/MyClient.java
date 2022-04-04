public class MyClient {
    public static void main(String[] args) {

        MyData.info();

        double wynik;
        CalcObject zObiekt;
        CalcObject2 zObiekt2;
        ResultType wynik2;
        InputType inObj;
        
        if(args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }

        if (System.getSecurityManager() == null) {
            System.getSecurityManager();
        }


        String adres1 = args[0];
        String adres2 = args[1];


        inObj = new InputType();
        inObj.x1 = 2.2;
        inObj.x2 = 3.3;
        inObj.operation = "add";

        try {
            zObiekt = (CalcObject) java.rmi.Naming.lookup(adres1);
            zObiekt2 = (CalcObject2) java.rmi.Naming.lookup(adres2);
            //tu cooos
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do "+adres1);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do "+adres1+" jest pobrana.");
        
        try {
            wynik = zObiekt.calculate(1.1, 2.2);
            wynik2 = zObiekt2.calculate(inObj);
        } catch (Exception e) {
            System.out.println("Błąd zdalnego wywołania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik1 = "+wynik);
        System.out.println("Wynik2 = " + wynik2.result);
        System.out.println("Opis wyniku 2: " + wynik2.result_description);
        return;
    }
}
