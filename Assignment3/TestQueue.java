import org.junit.jupiter.api.*;
import org.junit.jupiter.api.Assertions.*;
import java.io.*;

/**
 * TestQueue class
 * 
 * holds tests for all queue methods
 */
public class TestQueue {
	
	//allows you to print to a place where it can be tested
	private final PrintStream standardOut = System.out;
	private final ByteArrayOutputStream outputStreamCaptor = new ByteArrayOutputStream();

	@BeforeEach
	public void setOut(){
		System.setOut(new PrintStream(outputStreamCaptor));
	}

	//start of tests
	
	/**
	 * enqueueTestEmptyPeek()
	 *
	 * Test enqueue() when queue is empty dependant on peek()
	 * also Test peek() when queue has one item dependant on enqueue()
	 */
	@Test
	@DisplayName("Test enqueue(), empty queue, dependant on peek()")
	public void enqueueTestEmptyPeek(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hi");
		String actual = queue.peek();
		//Assert
		Assertions.assertEquals("Hi", actual);
	
	}

	/**
	 * enqueueTestEmptyLength()
	 *
	 * Test enqueue() when queue is empty dependant on length()
	 * also Test length() when queue has one item dependant on enqueue()
	 */
	@Test
	@DisplayName("Test enqueue(), empty queue, dependant on length()")
	public void enqueueTestEmptyLength(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hi");
		int actual = queue.length();
		//Assert
		Assertions.assertEquals(1, actual);
	}
	
	/**
	 * enqueueTestEmptyDump()
	 *
	 * Test enqueue() when queue is empty dependant on Dump()
	 * also Test Dump() when queue has one item dependant on enqueue()
	 */
	@Test
	@DisplayName("Test enqueue(), empty queue, dependant on Dump()")
	public void enqueueTestEmptyDump(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hi");
		queue.dump();
		String actual = outputStreamCaptor.toString().trim();
		//Assert
		Assertions.assertEquals("Hi", actual);

		
	}
	
	/**
	 * enqueueTestEmptyisEmpty()
	 *
	 * Test enqueue() when queue is empty dependant on isEmpty()
	 * also Test isEmpty() when queue has an item dependant on enqueue()
	 */
	@Test
	@DisplayName("Test enqueue(), empty queue, dependant on isEmpty()")
	public void enqueueTestEmptyisEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		boolean actual = queue.isEmpty();
		//Assert
		Assertions.assertFalse(actual);
	}
	
	/**
	 * enqueueTestAddEmpty()
	 *
	 * Test enqueue() when adding an empty string dependant on isEmpty()
	 */
	@Test
	@DisplayName("Test enqueue(), add empty string, dependant on isEmpty()")
	public void enqueueTestAddEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("");
		boolean actual = queue.isEmpty();
		//Assert
		Assertions.assertTrue(actual);
	}

	/**
	 * enqueueTestHasItemDump()
	 *
	 * Test enqueue() when queue has item dependant on dump()
	 * also Test dump() when queue has multiple items dependant on enqueue()
	 */
	@Test
	@DisplayName("Test enqueue(), when queue has item, dependant on dump()")
	public void enqueueTestHasItemDump(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		queue.enqueue("World");
		queue.dump();
		String actual = outputStreamCaptor.toString().trim();
		//Assert
		Assertions.assertEquals("Hello" + "\n" + "World", actual);
	}
	
	/**
	 * enqueueTestHasItemlength()
	 *
	 * Test enqueue() when queue has item dependant on length()
	 * also Test length() when queue has multiple items dependant on enqueue()
	 */
	@Test
	@DisplayName("Test enqueue(), when queue has item, dependant on length()")
	public void enqueueTestHasItemLength(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		queue.enqueue("World");
		int actual = queue.length();
		//Assert
		Assertions.assertEquals(2, actual);
	}

	/**
	 * peekTestMultiItems()
	 *
	 * Test peek() when queue has multiple items dependant on enqueue()
	 * test if first item still is returned after multiple enqueues
	 */
	@Test
	@DisplayName("Test peek(), when queue has multiple items, dependant on enqueue()")
	public void peekTestMultiItems(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		queue.enqueue("World");
		String actual = queue.peek();
		//Assert
		Assertions.assertEquals("Hello", actual);
	}

	/**
	 * peekTestEmpty()
	 *
	 * Test peek() when queue is empty
	 * see if "" is returned
	 */
	@Test
	@DisplayName("Test peek(), when queue is empty")
	public void peekTestEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		String actual = queue.peek();
		//Assign
		Assertions.assertEquals("", actual);
	}

	/**
	 * lengthTestEmpty()
	 *
	 * Test legnth() when queue is empty
	 * see if 0 is returned
	 */
	@Test
	@DisplayName("Test length(), when queue is empty")
	public void lengthTestEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		int actual = queue.length();
		//Assign
		Assertions.assertEquals(0, actual);
	}
	
	/**
	 * dumpTestEmpty()
	 *
	 * Test dump() when queue is empty
	 * see if "" is in console
	 */
	@Test
	@DisplayName("Test dump(), when queue is empty")
	public void dumpTestEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.dump();
		String actual = outputStreamCaptor.toString().trim();
		//Assign
		Assertions.assertEquals("", actual);
	}

	/**
	 * isEmptyTestEmpty()
	 *
	 * Test isEmpty() when queue is empty
	 * see if true is returned
	 */
	@Test
	@DisplayName("Test isEmpty(), when queue is empty")
	public void isEmptyTestEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		boolean actual = queue.isEmpty();
		//Assign
		Assertions.assertTrue(actual);
	}
	
	/**
	 * dequeueTestEmpty()
	 *
	 * Test dequeue() when queue is empty depending on isEmpty()
	 * see if true is returned
	 */
	@Test
	@DisplayName("Test dequeue(), empty queue, depending on isEmpty()")
	public void dequeueTestEmpty(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.dequeue();
		boolean actual = queue.isEmpty();
		//Assign
		Assertions.assertTrue(actual);
	}

	/**
	 * dequeueTestHasItem()
	 *
	 * Test dequeue() when queue has item depending on isEmpty() and enqueue()
	 * see if false then true is returned
	 */
	@Test
	@DisplayName("Test dequeue(), queue has item, depending on isEmpty() and enqueue()")
	public void dequeueTestHasItem(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		boolean actual1 = queue.isEmpty();
		queue.dequeue();
		boolean actual2 = queue.isEmpty();
		//Assign
		Assertions.assertFalse(actual1);
		Assertions.assertTrue(actual2);
	}

	/**
	 * dequeueTestMultiItemsLength()
	 *
	 * Test dequeue() when queue has multiple items depending on length() and enqueue()
	 * see if right count is returned is returned
	 */
	@Test
	@DisplayName("Test dequeue(), queue multiple items, depending on length() and enqueue()")
	public void dequeueTestMultiItemsLength(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		queue.enqueue("World");
		int actual1 = queue.length();
		queue.dequeue();
		int actual2 = queue.length();
		//Assign
		Assertions.assertEquals(2, actual1);
		Assertions.assertEquals(1, actual2);
	}

	/**
	 * dequeueTestMultiItemsDump()
	 *
	 * Test dequeue() when queue has multiple items depending on dump() and enqueue()
	 * see if right print is returned
	 */
	@Test
	@DisplayName("Test dequeue(), queue multiple items, depending on dump() and enqueue()")
	public void dequeueTestMultiItemsDump(){
		//Assign
		Queue queue = new Queue();
		//Act
		queue.enqueue("Hello");
		queue.enqueue("World");
		
		queue.dump();
		String actual1 = outputStreamCaptor.toString().trim();

		queue.dequeue();
		
		queue.dump();
		String actual2 = outputStreamCaptor.toString().trim();

		//Assign
		Assertions.assertEquals("Hello" + "\n" + "World", actual1);
		//console doesn't clear so next print adds to the end of the last one
		Assertions.assertEquals("Hello" + "\n" + "World" + "\n" + "World", actual2);
	}



}
