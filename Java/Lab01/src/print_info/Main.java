//package print_info;
import java.util.*;
import java.io.File;
import java.io.FileNotFoundException;

public class Main {

    public static void main(String[] args) {

        MyData.info();

        // Scanner
        formattedOutput();
        scanInput();
        scanWithRegularExpression();
        //readFile();

        // Collections
        presentVector();
        presentArrayList();
    }

    public static void formattedOutput() {
        System.out.println("=== Prezentacja wyjścia formatowanego ===");
        System.out.printf("Int: %d\n", 100);
        System.out.printf("PI = %.3f\n", Math.PI);
        System.out.printf("Float: %.2f\n", 221.44357784f);
        System.out.printf("With margin: %10.2f\n", 221.44357784f);
        System.out.println();
    }

    public static void scanInput() {
        System.out.println("=== Pobieranie danych z klawiatury ===");
        Scanner scanner = new Scanner(System.in);
        System.out.println("Podaj liczbę całkowitą");
        int n = scanner.nextInt();
        System.out.printf("Twoja liczba: %d\n", n);
        System.out.println("Podaj liczbę rzeczywistą");
        double r = scanner.nextDouble();
        System.out.printf("Twoja liczba: %f\n", r);
        System.out.println("Podaj swoje imię");
        String s = scanner.next();
        System.out.println("Imię: " + s);
        scanner.close();
        System.out.println();
    }

    public static void scanWithRegularExpression() {
        System.out.println("=== Odczytywanie Scannerem z wykorzystaniem wyrażeń regularnych ===");
        String input = "1 sheep 2 sheep one sheep two sheep";
        Scanner scanner = new Scanner(input).useDelimiter("\\s*sheep\\s*");
        System.out.println(scanner.nextInt());
        System.out.println(scanner.nextInt());
        System.out.println(scanner.next());
        System.out.println(scanner.next());
        System.out.println();
        scanner.close();
    }

    public static void readFile() {
        System.out.println("=== Odczytywanie danych z pliku ===");
        String path = "D:\\HDD\\Studia\\Systemy Rozproszone\\Systemy Rozproszone\\Java\\Lab01\\src\\print_info\\numbers.txt";
        try(Scanner scanner = new Scanner(new File(path))){
            while(scanner.hasNextLine()) {
                int n = scanner.nextInt();
                System.out.println(n);
            }
        }
        catch (FileNotFoundException e){
            e.printStackTrace();
        }
        System.out.println();
    }

    public static void presentVector(){
        System.out.println("=== Vector presentation ===");
        Vector<Integer> vec = new Vector<>();
        for(int i = 0; i<10; i++){
            vec.add(i);
        }
        System.out.printf("Vector size: %d\n", vec.size());
        System.out.printf("Vector capasity: %d\n", vec.capacity());
        Collections.shuffle(vec);
        System.out.println("Shuffled: " + vec);
        vec.sort(Comparator.comparingInt(o -> o));
        System.out.println("Sorted: " + vec);
        vec.sort(Comparator.comparingInt(o -> -o));
        System.out.println("Reversed: " + vec);
        System.out.println("Contains 3? " + vec.contains(3));
        for(int elem : vec) {
            System.out.println(elem);
        }
        System.out.println();
    }

    public static void presentArrayList(){
        System.out.println("=== ArrayList presentation ===");
        ArrayList<String> list = new ArrayList<>();
        for(int i=0; i<10; i++) {
            String sb = i + "#".repeat(i);
            list.add(sb);
        }
        System.out.printf("ArrayList size: %d\n", list.size());
        Collections.shuffle(list);
        System.out.println("Shuffled: " + list);
        list.sort(Comparator.comparing(String::length));
        System.out.println("Sorted via length: " + list);
        Collections.sort(list);
        System.out.println("Sorted alphabetically: " + list);
        System.out.println("Contains 3? " + list.contains("3"));
        for(String s: list){
            System.out.println(s);
        }
        System.out.println();
    }
}


