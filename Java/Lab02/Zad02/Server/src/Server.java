import org.apache.xmlrpc.WebServer;

import java.util.Vector;

public class Server {

    public static void main(String[] args) {
        int port = 10_011;
        System.out.println("Server XML-RPC is starting...");
        String serverId = "RSI_ZAD2";
        try {
            WebServer server = new WebServer(port);
            server.addHandler(serverId, new Server());
            server.start();
            System.out.println("Server is running.");
            System.out.println("Listening on port: " + port);
            System.out.println("To change the configuration press crl+c");
        } catch(Exception e) {
            System.err.println("Server" + e);
        }
    }

    public String show() {
        String ret = """
                show() -> returns this message.
                distance(double lat1, double lon1, double lat2, double lon2) -> returns the distance between two points on Earth.
                myPrimes(int min, int max) -> returns primes count between specified min and max values and the value of the greatest prime in that sequence.
                calculateBmi(double mass, double height) -> returns BMI (double).
                getPyramidAsync(int height, char symbol) -> return a string pyramid made out of given symbol.
                triangleSurface(double a, double b, double c) -> returns a surface of specified triangle (double).
                """;
        return ret;
    }

    // Wrocław: 51.1 17.02
    // Warszawa: 52.22 21.02
    // Olsztyn: 53.77 20.47
    public double distance(double latitude1, double longitude1, double latitude2, double longitude2) {
        double radius = 6371; // Earth radius in km
        double lat1 = toRad(latitude1);
        double lon1 = toRad(longitude1);
        double lat2 = toRad(latitude2);
        double lon2 = toRad(longitude2);
        return 2 * radius * Math.asin(Math.sqrt(hav(lat2 - lat1) + (1 - hav(lat1 + lat2) - hav(lat1 - lat2)) * hav(lon2 - lon1)));
    }

    private double toRad(double degree) {
        return degree * Math.PI / 180;
    }

    private double hav(double value) {
        return Math.sin(value / 2) * Math.sin(value / 2);
    }

    public Vector<Integer> myPrimes(int min, int max) {
        var ret = new Vector<Integer>();
        if(min > max) {
            ret.addElement(-1);
            ret.addElement(-1);
            return ret;
        }
        int currentMax = -1;
        int primeCounter = 0;
        for(int i = min; i <= max; i++) {
            if(isPrime(i)) {
                primeCounter++;
                if(i > currentMax) {
                    currentMax = i;
                }
            }
        }
        ret.addElement(primeCounter);
        ret.addElement(currentMax);
        return ret;
    }

    private boolean isPrime(int number) {
        if(number < 1)
            return false;
        if(number == 2 || number == 3)
            return true;
        if(number % 2 == 0 || number % 3 == 0)
            return false;
        int i = 5;
        while(i * i <= number) {
            if(number % i == 0 || number % (i + 2) == 0)
                return false;
            i += 6;
        }
        return true;
    }

    public String getPyramidAsync(int height, String symbol) {
        String spaces = " ".repeat(height - 1);
        String shape = symbol;
        StringBuilder ret = new StringBuilder();
        for(int i=0; i<height; i++) {
            ret.append(spaces);
            ret.append(shape);
            shape += symbol + symbol;
            ret.append('\n');
            if(spaces.length() == 0) spaces = "";
            else spaces = spaces.substring(0, spaces.length() - 1);
        }
        return ret.toString();
    }

    public Double calculateBMI(double mass, double height) {
        return mass / (height * height);
    }

    public Double triangleSurface(double a, double b, double c) {
        double p = (a + b + c) / 2;
        return Math.sqrt(p * (p - a) * (p - b) * (p - c));
    }
}
