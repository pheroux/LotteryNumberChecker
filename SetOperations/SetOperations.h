#pragma once

#include <set>
#include <string>
#include <istream>

// This function reads a set of integers from an input stream and returns it
std::set<int> read_set_from_stream(std::istream& input_stream);

// This function computes the intersection of two sets of integers and returns it
std::set<int> intersection_of_sets(const std::set<int>& set1, const std::set<int>& set2);

extern "C" {
    __declspec(dllexport) void compute_intersection_of_arrays(int* array1, int array1Size, int* array2, int array2Size, int* outputArray, int* outputSize);
}