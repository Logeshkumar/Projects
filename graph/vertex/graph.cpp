/////////////////////////////////////////////////////////////////////
//  graph.cpp - Helps in constructing the graph                      //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

#include"graph.h"

#ifdef TEST_GRAPH_H
int main()
{
	
	g.AddVertex(V1);
	g.AddVertex(V2);
	g.AddVertex(V3);
	g.AddVertex(V4);
	g.AddVertex(V5);
	g.AddVertex(V6);
	g.AddVertex(V7);
	g.AddVertex(V8);
	g.AddVertex(V9);
	g.AddVertex(V10);
	g.AddVertex(V11);
	g.AddVertex(V12);
	std::cout<<" The Depth for search for the node Entered"<<std::endl;
	g.DFS(V1);
	g.DepthFSearch();
	std::cout<<"Strong Components of the graph"<<std::endl;
	g.StrongComponents();  
	
}
#endif