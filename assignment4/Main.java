public class Main{

	public static void main(String[] args) {
		StrHashTableCollisions h1 = new StrHashTableCollisions(5);

		

		h1.insert("2", "jump");
		h1.insert("hi", "hi");
		h1.insert("hello", "1");
		h1.insert("3", "4");
		h1.insert("T", "test");
		h1.insert("0", "hello");

		h1.dump();

		h1.insert("a", "3");
		h1.insert("b", "2");
		h1.insert("4", "do");

		h1.dump();
		
		System.out.println(h1.size());
		
		Node node = h1.get("2");
		System.out.println(node.getKey() + ", " + node.getValue());
	}

}
