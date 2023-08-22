public class testLinkedList
{
	public static void main(String [] args) 
	{
		UnOrdStrList list = new UnOrdStrList();
		OrdStrList ordList = new OrdStrList();
		System.out.println(list.isEmpty());
		list.add("word");

		System.out.println("is word in list");
		System.out.println(list.find("word"));
		
		list.remove("pass");

		System.out.println(list.find("word"));

		list.add("word");
		list.add("word");
		list.add("good");
		list.add("pass");

		System.out.println(list.find("word"));

		list.remove("word");
		System.out.println(list.find("word"));
		list.dump();
		System.out.println(list.isEmpty());
		System.out.println(list.length());
		
		System.out.println(ordList.isEmpty());
		ordList.insert("word");

		System.out.println("is word in list");
		System.out.println(ordList.find("word"));
		
		ordList.remove("pass");

		System.out.println(ordList.find("word"));

		ordList.insert("word");
		ordList.insert("good");
		ordList.insert("are");
		ordList.insert("word");
		ordList.insert("a");
		ordList.insert("aa");
		ordList.insert("food");
		ordList.insert("good");

		System.out.println(ordList.find("word"));

		ordList.remove("word");
		ordList.remove("man");
		System.out.println(ordList.find("word"));
		ordList.dump();
		System.out.println(ordList.isEmpty());
		System.out.println(ordList.length());
		
	}
}
