import java.util.Vector;
import java.util.Scanner;

public class ConsoleController {

    private Vector<Object> buffer;
    private Scanner scanner;
    private String method;
    private String command;
    public boolean isReady = false;
    public boolean isAsync = false;

    public ConsoleController() {
        buffer = new Vector<>();
        scanner = new Scanner(System.in);
        method = "";
        command = "";
    }

    public void input() {
        getCommand();
        boolean success = processCommand();
        if(success) {
            print("OK");
        } else {
            print("Incorrect command or data format");
        }
    }

    private void getCommand(){
        if(scanner.hasNext()){
            command = scanner.nextLine();
        }
    }

    private boolean processCommand() {
        String[] parts = command.split("\\s+");
        boolean success = true;
        try {
            switch (parts[0].toLowerCase()) {
                case "clear":
                    clear();
                    break;
                case "send":
                    if(parts.length > 1){
                        if(parts[1].equalsIgnoreCase("async")){
                            isAsync = true;
                            isReady = true;
                        } else {
                            success = false;
                        }
                    } else {
                        isReady = true;
                    }
                    break;
                case "data":
                    print(method);
                    for(var elem: buffer) {
                        print(elem);
                    }
                    break;
                case "method":
                    method = parts[1];
                    break;
                case "int":
                    buffer.addElement(Integer.parseInt(parts[1]));
                    break;
                case "str":
                    buffer.addElement(parts[1]);
                    break;
                case "double":
                    buffer.addElement(Double.parseDouble(parts[1]));
                    break;
                default:
                    success = false;
            }
        } catch(IndexOutOfBoundsException | NumberFormatException e) {
            success = false;
        }
        return success;
    }

    public void clear() {
        clearBuffer();
        isAsync = false;
        isReady = false;
    }

    public boolean clearBuffer() {
        buffer.clear();
        return true;
    }

    public int loadInt() {
        int i = scanner.nextInt();
        buffer.addElement(i);
        return i;
    }

    public double loadDouble() {
        double d = scanner.nextDouble();
        buffer.addElement(d);
        return d;
    }

    public String loadString() {
        String s = scanner.next();
        buffer.addElement(s);
        return s;
    }

    public void print(Object obj) {
        System.out.println(obj);
    }

    public void print(Object... obj) {
        for(var o: obj) {
            print(o);
        }
    }

    public Vector<Object> getBuffer() {
        return buffer;
    }

    public String getMethod() {
        return method;
    }

}
