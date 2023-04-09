#include "pch.h" // precompiled header
#include "SetOperations.h"
#include <algorithm>
#include <iterator>
#include <sstream>

// This function reads a set of integers from an input stream and returns it
std::set<int> read_set_from_stream(std::istream& input_stream) {
    std::set<int> result;
    int number;
    // read each integer from the input stream and insert it into the set
    while (input_stream >> number) {
        result.insert(number);
    }

    return result;
}

// This function computes the intersection of two sets of integers and returns it
std::set<int> intersection_of_sets(const std::set<int>& set1, const std::set<int>& set2) {
    std::set<int> intersection;

    // use the std::set_intersection algorithm to compute the intersection of the two sets
    std::set_intersection(set1.begin(), set1.end(), set2.begin(), set2.end(),
        std::inserter(intersection, intersection.begin()));

    return intersection;
}

// This function computes the intersection of two arrays and stores the result in the output array.
// It takes the input arrays and their sizes, an output array, and a pointer to an integer representing the output size.
void compute_intersection_of_arrays(int* array1, int array1Size, int* array2, int array2Size, int* outputArray, int* outputSize)
{
    // Create a set for each input array and copy the elements from the arrays to the sets.
    std::set<int> set1;
    std::copy(array1, array1 + array1Size, std::inserter(set1, set1.begin()));

    std::set<int> set2;
    std::copy(array2, array2 + array2Size, std::inserter(set2, set2.begin()));

    // Compute the intersection of the sets using the intersection_of_sets helper function.
    std::set<int> intersectionSet = intersection_of_sets(set1, set2);

    // Set the output size to the size of the intersection set.
    *outputSize = intersectionSet.size();

    // Copy the elements from the intersection set to the output array.
    std::copy(intersectionSet.begin(), intersectionSet.end(), outputArray);
}

