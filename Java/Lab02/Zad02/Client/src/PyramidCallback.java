import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;

public class PyramidCallback implements AsyncCallback {

    public String pyramid;

    public PyramidCallback() {
        pyramid = "";
    }
    @Override
    public void handleResult(Object result, URL url, String method) {
        pyramid = (String) result;
        System.out.println(pyramid);
    }

    @Override
    public void handleError(Exception err, URL url, String method) {
        System.err.println("Pyramid async: " + err);
    }
}
