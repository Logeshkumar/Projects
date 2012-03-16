/////////////////////////////////////////////////////////////////////
//  Display.h - Helps in displaying the ouput                      //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
This module is basically used for displaying the ouput to the console 
window. The display function are called by the executive package in 
order to execute the display functions. This is basically done to separate
execution logic from the displaying.
Public Interface:
=================
DisplayGraph()==> This is used to display the graph structure for the vertices inputted
DisplayDFS(); ==> This is used to display the Depth for search for te vertices in the graph
DisplayStrongComp(std::map<int,std::vector<std::string>>); ==> this is used to display the Strong components in the graph

Build Process:
=============
This is an independent module. Only library functions are required
Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/

#ifndef DISPLAY_H
#define DISPLAY_H

#include"graph.h"
#include"Global.h"
#include<vector>
#include<map>
#include<string>

template<class V,class E>
class Display
{
	static int Count;
public:
	void DisplayGraph();
	void DisplayDFS();
	void DisplayStrongComp(std::map<int,std::vector<V>>);
	void DisplayGlobalEdge(std::map<V,std::vector<std::pair<V,E>>>);
};
template<class V,class E>
int Display<V,E>::Count; // static variable used for displaying strong components

//This is used to display the strong components in the graph
template<class V,class E>
void Display<V,E>::DisplayStrongComp(std::map<int,std::vector<V>> DispMap)
{
	Count = 0;
	graph<std::string,std::string> g;
		 for( std::map<int, std::vector<V> >::iterator iter = DispMap.begin(); iter !=DispMap.end(); ++iter ) 
		 {   
			 int Key = (*iter).first;
			 if(Count <Key)
			 {
				 std::cout<<std::endl<<std::endl<<"The strong component"<<std::endl;
				 std::cout<<"*******************************************************************************"<<std::endl;
		 std::vector<V> TempVect = (*iter).second;
		 std::vector<V>::iterator it;
		 for(it=TempVect.begin();it!=TempVect.end();it++)
		 {
			 std::cout<<*it<<std::endl;
		 }
		std::cout<<"*******************************************************************************"<<std::endl;
		 }
		 }
	 }


// Display the Edges in the graph(same value as inputted)
template<class V,class E>
void Display<V,E>::DisplayGlobalEdge(std::map<V,std::vector<std::pair<V,E>>> GlobMap)
{
	 for( std::map<V, std::vector<std::pair<V,E>>>::iterator iter = GlobMap.begin(); iter !=GlobMap.end(); ++iter ) 
		 {  
			 std::string Parent = (*iter).first;
			 std::cout<<std::endl<<"=============================================================================="<<std::endl;
			 std::cout<<"Parent "<<Parent+":";
			 std::cout<<std::endl<<"=============================================================================="<<std::endl;
			 
		  
		 std::vector<std::pair<V,E>> TempVect = (*iter).second;
		 std::vector<std::pair<V,E>>::iterator it;
		 for(it=TempVect.begin();it!=TempVect.end();it++)
		 {
			 std::pair<V,E> inspair = (*it);
			 std::cout<<std::endl<<"=============================================================================="<<std::endl;
			 std::cout<<"Child "<<inspair.first<<":"<<std::endl<<"Edge: "<<inspair.second;
			  std::cout<<std::endl<<"=============================================================================="<<std::endl;
		 }
	 }
}


//This is used to display the graph structure for the vertices inputted
template<class V,class E>
void Display<V,E>::DisplayGraph()
{
	graph<V,E> g;
	std::vector<Vertex<V,E>> Vec = g.GetAdjVector();
	std::vector<Vertex<V,E>>::iterator it;
	for(it = Vec.begin(); it!=Vec.end(); ++it)
	   {
		    std::vector<std::pair<int,V>> dep = (*it).GetObjectVector()  ;
		    if(dep.size()==0)
			{
				std::cout<<std::endl<<std::endl<<std::endl;
				std::cout<<"============================================================================ "<<std::endl;
				std::cout<<(*it).GetUserId()<<": Does not have any child nodes"<<std::endl;
				std::cout<<"============================================================================ "<<std::endl<<std::endl<<std::endl;
			}
			else if(dep.size()!=0)
			{
			std::cout<<std::endl<<std::endl<<std::endl;
			std::cout<<(*it).GetUserId()<< " :: Node is connected to the following nodes via edges "<<std::endl;
			std::cout<<"============================================================================ "<<std::endl;
			std::vector<std::pair<int,V>>::iterator insideit;
			for(insideit = dep.begin(); insideit!=dep.end(); ++insideit)
			{    
				std::pair<int,V> result = (*insideit);
				std::cout<<g.getObject((*insideit).first).GetUserId();
				std::cout<<" --> ";
				std::cout<<(*insideit).second<<std::endl;
			}
			std::cout<<"============================================================================ "<<std::endl<<std::endl<<std::endl;
          }
	 }
}

# endif