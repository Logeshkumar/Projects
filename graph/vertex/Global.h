/////////////////////////////////////////////////////////////////////
//  Global.h - Helps in displaying the ouput                      //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
This is the module which implements two global algorithms for determinig
same value of a vertex or an edge i.e for any given value of a vertex if an 
equilent value is determined in the graph then those values are displayed.
Similarly the other global algorithm displays the same value as the edge
value inputted.
Public Interface:
=================
 SameVertex(V) ==> this is the function which displays the 
 global algorithm which displays the value of a vertex for
 an equal value inputted
 SameEdge(E)==>this is the function which displays the 
 global algorithm which displays the value of a edge for
 an equal value inputted

Build Process:
=============
This is a separate package which implemets two global algorithms for 
determining same value of a vertex and an edge.

This file depends on  graph.h.graph.cpp,vertex.h,vertex.cpp
Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/






#ifndef GLOBAL_H
#define GLOBAL_H

#include "graph.h"
#include "Vertex.h"
#include<string>

template<class V,class E>
class Global
{
	std::map<V,std::vector<std::pair<V,E>>> GlobalMap;
    
	static std::vector<V> Vert;
public:
    void SameVertex(V);
	void SameEdge(E);
	std::map<V,std::vector<std::pair<V,E>>> GetGlobalMap();

};


template<class V,class E>
std::vector<V> Global<V,E>::Vert;

//template<class V,class E>
//std::vector<std::pair<V,E>> Global<V,E>::vect;

template<class V,class E>
std::map<V,std::vector<std::pair<V,E>>> Global<V,E>::GetGlobalMap()
{
	return GlobalMap;
}

//template<class V,class E>
//std::map<V,std::vector<std::pair<V,E>>> Global<V,E>::GlobalMap;

//this is the function which displays the 
//global algorithm which displays the value of a vertex for
// an equal value inputted
template<class V,class E>
void Global<V,E>::SameVertex(V var)
{
	graph<V,E> g;
	std::string data = var;
    std::transform(data.begin(), data.end(), data.begin(), ::toupper);
	var = data;
	std::vector<Vertex<V,E>> Vectr = g.GetAdjVector();
	std::vector<Vertex<V,E>>::iterator it;
	std::cout<<std::endl;
	std::cout<<std::endl<<std::endl<< "Global algorithm ouput for vertices" <<std::endl;
	std::cout<<std::endl;
	for(it = Vectr.begin(); it!=Vectr.end(); ++it)
	{	
		if((*it).GetUserId() == var)
		{
			std::cout<<var<<" ---> ";
			std::cout<<(*it).Getid()<<std::endl;
			Vert.push_back(var);
		}
	}
	std::cout<<std::endl;
}


//this is the function which displays the 
//global algorithm which displays the value of a edge for
//an equal value inputted	
template<class V,class E>
void Global<V,E>::SameEdge(E var)
{
	graph<V,E> g;
	std::vector<Vertex<V,E>> Vectr = g.GetAdjVector();
	std::cout<< "Global algorithm ouput for Edges"<<std::endl;
	std::cout<<std::endl;

	std::vector<Vertex<V,E>>::iterator it;
	for(it = Vectr.begin(); it!=Vectr.end(); ++it)
  {
	  std::vector<std::pair<V,E>> vect;
	  std::vector<std::pair<int,E>> Vect = (*it).GetObjectVector();
	  std::vector<std::pair<int,E>>::iterator insideit;
	  for(insideit = Vect.begin(); insideit!=Vect.end(); ++insideit)
	  {
		std::pair<int,E> result = (*insideit);
		std::string var1 = result.second;
		if(var1 == var)
		{
			try
			{
		   Vertex<V,E> v = g.getObjectforGlobal(result.first);
		   Vertex<V,E> v1 = g.getObjectforGlobal((*it).Getid());
		   std::pair<V,E> P;
		   P.first = v.GetUserId();
		   P.second = var;
		   vect.push_back(P);
		   GlobalMap[v1.GetUserId()] = vect;
			}
			catch(std::exception& ex)
			{
				std::cout<<ex.what();
			}
		}
	 }
  }
	std::cout<<std::endl;
}



# endif