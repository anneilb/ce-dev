package exercise2;

import java.lang.reflect.Array;
import java.util.Arrays;

public class SortArrayPerformance {

	private static final int SIZE_50K = 50000;
	private static final int SIZE_100K = 100000;
	private static final int SIZE_150K = 150000;
	private static final int SIZE_200K = 200000;
	private static final int SIZE_250K = 250000;
	private static final int SIZE_300K = 300000;
	private static final String MS = "ms";
		
	public static void main(String[] args) {
		
		SortArrayPerformance sortPerformance = new SortArrayPerformance();
		
		sortPerformance.generateHeadings();
		sortPerformance.testArraySize(SIZE_50K);
		sortPerformance.testArraySize(SIZE_100K);
		sortPerformance.testArraySize(SIZE_150K);
		sortPerformance.testArraySize(SIZE_200K);
		sortPerformance.testArraySize(SIZE_250K);
		sortPerformance.testArraySize(SIZE_300K);		
	}
	
	public void generateHeadings(){
		
		System.out.println("Array size\t|Bubble Sort\tMerge Sort\tQuick Sort\tHeap Sort\tRadix Sort\t");
		System.out.println("------------------------------------------------------------------------------------------\t");
	}
	
	public void testArraySize(int size){			
		
		int[] list = createTestArray(size);
		
		//Build and display the output
		String output = size + "\t\t|";		
		System.out.print(output);

		long[] results = performTest(list);
		System.out.println("");	
				
//		for(long x: results)
//			output += pad(x + "ms");
//		
//		System.out.println(output);		
	}		
	
	private int[] createTestArray(int size){
		
		int[] testArray = new int[size];
		
		for(int x = 0; x < testArray.length; x++)
		{
			testArray[x] = (int)(Math.random() * testArray.length);			
		}
		
		return testArray;
	}
	
	private long[] performTest(int[] list){
	
		long[] results = new long[5];
		long startTime;
		
		//Create copies of the original test array, so we have 
		//equivalent test data for use by each sorting algorithm
		int[] list1 = Arrays.copyOf(list, list.length);
		int[] list2 = Arrays.copyOf(list, list.length);
		
		//Copy the list contents to an Integer[] array for use by HeapSort algorithm
		Integer[] list3 = new Integer[list.length];
		for(int x=0; x < list.length; x++)
			list3[x] = list[x];
					
		int[] list4 = Arrays.copyOf(list, list.length);		
		
	    startTime = System.currentTimeMillis();
		BubbleSort.bubbleSort(list);		
		results[0] = System.currentTimeMillis() - startTime;
		System.out.print(pad(results[0] + MS));		
		
		startTime = System.currentTimeMillis();
		MergeSort.mergeSort(list1);
		results[1] = System.currentTimeMillis() - startTime;
		System.out.print(pad(results[1] + MS));
		
		startTime = System.currentTimeMillis();
		QuickSort.quickSort(list2);
		results[2] = System.currentTimeMillis() - startTime;
		System.out.print(pad(results[2] + MS));		
		
		startTime = System.currentTimeMillis();		
		HeapSort.heapSort(list3); //pass Integer[] array
		results[3] = System.currentTimeMillis() - startTime;
		System.out.print(pad(results[3] + MS));		
		
		startTime = System.currentTimeMillis();
		RadixSort.radixSort(list4);
		results[4] = System.currentTimeMillis() - startTime;
		System.out.print(pad(results[4] + MS));		
		
		return results;
	}
	
	
	private String pad(String value){	
		if(value.length() >=7)
			return value += "\t";
		else
			return value += "\t\t";	
	}
	
}
