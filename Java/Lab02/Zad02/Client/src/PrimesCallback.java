import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;
import java.util.Vector;

public class PrimesCallback implements AsyncCallback {
    @Override
    public void handleResult(Object res, URL url, String method) {
        var result = (Vector<Integer>)res;
        int numberOfPrimes = result.get(0);
        int maxPrime = result.get(1);
        if(numberOfPrimes == -1) {
            System.out.println("Incorrect data format");
            return;
        }
        System.out.println("Primes found: " + numberOfPrimes);
        if(maxPrime != -1) {
            System.out.println("Max prime: " + maxPrime);
        }
    }

    @Override
    public void handleError(Exception err, URL url, String method) {
        System.err.println("Error from " + method);
        System.err.println(err.toString());
    }
}
