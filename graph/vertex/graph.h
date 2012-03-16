/////////////////////////////////////////////////////////////////////
//  graph.h - Helps in constructing the graph                      //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
This module is an important package in this project. because the whole graph
construction for the files in the input path is maintained here. It has various 
functions for constructing graph, maintaining the structure, determining the
strong componnets, performing depth for search
Public Interface:
=================
AdjchildVector(Vertex<V,E> &) ==> this function holds the 
IsStrong(Vertex<V,E> & ); ==> function used to determine strong components
StrongComponents() ==>strong components algorithm function
getObject(int) ==> returns a particular object for the identity of the vertex inputted
getxmlObject(V) ==> this is obtain a vertex object for a particular value given
AddVertex(Vertex<V,E> &) ==> adding the vertex to the adjacency vector
AddEdge(Vertex<V,E> &,Vertex<V,E> &,E) ==>adding edge to the adjacency vector
GetAdjVector()  ==> it gets the adjacancency vector where all the vertex objects are stored
DepthFSearch()  ==> depth for search function
DFS(Vertex<V,E> &) ==> depth for search function for particular vertex;
getObjectforGlobal(int i) ==> used to return the object for tthe particular Id inputte
std::map<int,std::vector<std::string>> GetMap() ==> gets the map for 
std::vector<Vertex<V,E>> GetAdjacency() ==> returns a vector of vertice objects in the graph
std::stack<Vertex<V,E>> GetDetStrong(); ==> returns vector of objects used for determinig strong components
ObjectSync() ==> used sync the objects
ObjectSync1(Vertex<V,E> &) ==> used to sync the objects

Build Process:
=============
This is a separate package which implemets two global algorithms for 
determining same value of a vertex and an edge.

Required files are vertex.h,vertex.cpp.
Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/






#ifndef GRAPH_H
#define GRAPH_H
#include"Vertex.h"
#include<vector>
#include<list>
#include<string>
#include<map>
#include<algorithm>
#include<stack>


//functor interfce
template <class V,class E>
struct IFunctor
{
  virtual void operator()(Vertex<V,E>&)=0;
};



//graph class
template<class V,class E>
class graph
{
	static std::vector<Vertex<V,E>> AdjacencyVec;
	static std::vector<int> marked;
	bool Visited(Vertex<V,E> &);
	std::vector<Vertex<V,E>> StrongCompVec;
	static std::stack<Vertex<V,E>> DetStrong;
	std::map<int,std::pair<int,int>> Strong;
	int i;
	static int disp;
	std::map<int,std::vector<std::string>> dispMap;
public:
	std::vector<std::pair<int,std::string>> AdjchildVector(Vertex<V,E> &);
	void IsStrong(Vertex<V,E> & );
    void StrongComponents();
	Vertex<V,E> getObject(int);
	Vertex<V,E> getxmlObject(V);
	void AddVertex(Vertex<V,E> &);
	void AddEdge(Vertex<V,E> &,Vertex<V,E> &,E);
	std::vector<Vertex<V,E>> GetAdjVector();
	void DepthFSearch();
	void DFS(Vertex<V,E> &,IFunctor<V,E>&);
	Vertex<V,E> getObjectforGlobal(int i);
	std::map<int,std::vector<std::string>> GetMap();
	std::vector<Vertex<V,E>> GetAdjacency();
	std::stack<Vertex<V,E>> GetDetStrong();
	void ObjectSync();
	void ObjectSync1(Vertex<V,E> &);

	};


//functor printing function
template<class V,class E>
class aFunctor : public IFunctor<V,E>
{
  void operator()(Vertex<V,E> &ob)
  {
    std::cout<<std::endl<<ob.GetUserId();
  }
};


template<class V,class E>
std::vector<int> graph<V,E>::marked;

template<class V,class E>
int graph<V,E>::disp = 0;

template<class V,class E>
std::stack<Vertex<V,E>> graph<V,E>::DetStrong;


template<class V,class E>
std::vector<Vertex<V,E>> graph<V,E>::GetAdjacency()
{
	return AdjacencyVec;
}

template<class V, class E>
std::stack<Vertex<V,E>> graph<V,E>::GetDetStrong()
{
	return Detstrong;
}
template<class V,class E>
std::vector<Vertex<V,E>> graph<V,E>::AdjacencyVec;

// Adding the vertex to the adjacency vector
template<class V, class E>
void graph<V,E>::AddVertex(Vertex<V,E> &obj)
{
	static std::vector<int> GraphVec;
	if(GraphVec.size() == 0)
	{
		GraphVec.push_back(obj.Getid());
		AdjacencyVec.push_back(obj);
	}
	else if (GraphVec.size()>0)
	{
	   for(unsigned i=1; i<=GraphVec.size();i++)
	    {
		std::vector<int>::iterator it;
	    it = find (GraphVec.begin(), GraphVec.end(),obj.Getid());
		if(it==GraphVec.end())
		  {
		   GraphVec.push_back(obj.Getid());
		   AdjacencyVec.push_back(obj);
		  }
	    }
	}
}



// returns the adjacency vector
template<class V,class E>
std::vector<Vertex<V,E>> graph<V,E>::GetAdjVector()
{
	return this->AdjacencyVec;
}



// function to perform depth for search for particular vertices object inputted
template<class V,class E>
void graph<V,E>::DFS(Vertex<V,E> &object,IFunctor<V,E> &f)
{
	f(object);
	marked.push_back(object.Getid());
	std::vector<std::pair<int,E>> DFSVec;
    DFSVec = object.GetObjectVector();
	for(unsigned iter = 0;iter< DFSVec.size();iter++)
	{
		int i = DFSVec[iter].first;
		try {
		  Vertex<V,E> Vd = getObject(DFSVec[iter].first);
		
		  if(Visited(Vd)==false)
			continue;
		  else
		  {

				DFS(Vd,f);
		  }
		} 
		catch(std::exception& ex)
		{
			std::cout<<ex.what();
	      continue;
		}
	}
}

// performing depth for over a set of vertices
template<class V,class E>
void graph<V,E>::DepthFSearch()
{
	aFunctor<V,E> af;
	std::vector<Vertex<V,E>>::iterator it;
	for(it =  AdjacencyVec.begin(); it!= AdjacencyVec.end(); ++it)
	{
		if(Visited(*it) == true)
		DFS(*it,af);
	}
}

// a function to determine if the node has been visited or not
template<class V,class E>
bool graph<V,E>::Visited(Vertex<V,E> &objec)
{
	std::vector<int>::iterator it;
	it = find(marked.begin(),marked.end(),objec.Getid());
		if(it == marked.end())
		{
			return true;
		}
		else
			return false;
}

// adding child components or dependencies to the particualr vertices
//through there corresponding edges
template<class V,class E>
void graph<V,E>::AddEdge(Vertex<V,E> &val1,Vertex<V,E> &val2,E val3)
{	
	std::pair<int,E> InsidePair;
	InsidePair.first = val2.Getid();
    InsidePair.second = val3;
	std::list<std::pair<int,E>> myList;
	myList.push_back(InsidePair);
	std::pair<int,std::list<std::pair<int,E>>> Vedge(val1.Getid(),myList);
	static std::vector<std::pair<int,std::list<std::pair<int,E>>>> Vedgelist;
	Vedgelist.push_back(Vedge);	
}

// returns the particular object for the particular
//identity inputted
template<class V,class E>
Vertex<V,E> graph<V,E>::getObject(int i)
{
	std::vector<Vertex<V,E>>::iterator it;
	for(it = AdjacencyVec.begin();it!=AdjacencyVec.end();++it)
	{
		if (i == (*it).Getid())
		{
			return (*it);
		}
	}
	throw std::exception();
}

// this is obtain a vertex object for a particular 
// value given

template<class V,class E>
Vertex<V,E> graph<V,E>::getxmlObject(V ti)
{
	static std::vector<Vertex<V,E>> Vectr = Vertex<std::string,std::string>::getstoredVector();

    std::vector<Vertex<V,E>>::iterator it;
	for(it = Vectr.begin();it!=Vectr.end();++it)
	{
		if (ti == (*it).GetUserId())
		{
			return *it;
		}
	}
	throw std::exception();
}

// this is a function basically written to maintain 
//synchronisation between objects
template<class V,class E>
void graph<V,E>::ObjectSync()
{
	std::stack<Vertex<V,E>> objectsync = DetStrong;
		while(objectsync.size()!=0)
		{
			Vertex<V,E> Vt = objectsync.top();
			objectsync.pop();
	        std::vector<Vertex<V,E>>::iterator iter1;
	       for(iter1 = AdjacencyVec.begin(); iter1!= AdjacencyVec.end();iter1++)
	        {
			if((*iter1).GetUserId()==Vt.GetUserId())
		      {
			   (*iter1).num = Vt.num;
			   (*iter1).lowlink = Vt.lowlink;
		       }
		    }
		}
}


// this is a function basically written to maintain 
//synchronisation between objects
template<class V,class E>
void graph<V,E>::ObjectSync1(Vertex<V,E> & obj)
{
	std::stack<Vertex<V,E>> myS = DetStrong;
	std::stack<Vertex<V,E>> properStack;
	for(unsigned l=0;l<DetStrong.size();l++)
	{
		int flg=0;
		Vertex<V,E> Vtv = myS.top();
		myS.pop();
		if(Vtv.GetUserId() == obj.GetUserId())
		{
			Vtv.lowlink=obj.lowlink;
			
			properStack.push(Vtv);
			flg=1;
		}
		if(flg==0)
		properStack.push(Vtv);
		
	}
	DetStrong = properStack;
}

// returns a map to display package for displaying
//the contents in the map
template<class V,class E>
std::map<int,std::vector<std::string>> graph<V,E>::GetMap()
{
	return dispMap;
}

//this function is used by the Global algorithms for getting
//an vertex object for the particular identity inputted
template<class V,class E>
Vertex<V,E> graph<V,E>::getObjectforGlobal(int i)
{
	std::vector<Vertex<V,E>>::iterator it;
	for(it =  AdjacencyVec.begin();it!= AdjacencyVec.end();++it)
	{
		if (i == (*it).Getid())
		{
			return *it;
		}
	}
	throw std::exception();
}

// adding the child dependencies to the the parent vertice objects
template<class V,class E>
std::vector<std::pair<int,std::string>> graph<V,E>::AdjchildVector(Vertex<V,E> &objec)
{
	std::vector<Vertex<V,E>>::iterator it;
	for(it = AdjacencyVec.begin(); it!= AdjacencyVec.end();it++)
	{
		if((*it).GetUserId() == objec.GetUserId())
		{
			return (*it).GetObjectVector();
		}
	}
	throw std::exception();
}

// Determing the strong components in the graph
template<class V,class E>
void graph<V,E>::StrongComponents()
{
	i =0;
	std::vector<Vertex<V,E>>::iterator it;
	for(it = AdjacencyVec.begin(); it!= AdjacencyVec.end();it++)
	{
		(*it).num = 0;
		(*it).lowlink = 0;

	}

	std::vector<Vertex<V,E>>::iterator iter;
	for(iter = AdjacencyVec.begin(); iter!= AdjacencyVec.end();iter++)
	{
		if((*iter).num==0)
		{
			
			IsStrong(*iter);
		}
	}
}

//recursive function used to recurse through the other vertices to 
//determine the strong componets in the graph
template<class V, class E>
void graph<V,E>::IsStrong(Vertex<V,E> &obj)
	{	i=i+1;
		obj.num = i;
		obj.lowlink = i;
		DetStrong.push(obj);
		ObjectSync();
		try{
		std::vector<std::pair<int,std::string>> dep = AdjchildVector(obj);
		std::vector<std::pair<int,std::string>>::iterator insideit;
		for(insideit = dep.begin(); insideit!=dep.end(); ++insideit)
	{    
		std::pair<int,std::string> result = (*insideit);
		int p = (*insideit).first;
		Vertex<V,E> Vert= getObject(p);
		if(Vert.num == 0)
		{ IsStrong(Vert);
		  obj.lowlink =  (obj.lowlink<Vert.lowlink) ? obj.lowlink:Vert.lowlink;
		  ObjectSync1(obj);
		}
		else if(Vert.num < obj.num)
		{
			std::stack<Vertex<V,E>> mystack = DetStrong;
			for(unsigned it2=0;it2 <DetStrong.size();it2++)
	       {
			    Vertex<V,E> V1 = mystack.top();
			    mystack.pop();
				if(Vert.num == V1.num)
			   {
				obj.lowlink = (obj.lowlink<Vert.num) ? obj.lowlink:Vert.num;
				ObjectSync1(obj);
				}
			}
		}
	 }
  }
		catch(exception& ex){
			std::cout<<ex.what();}
	if(obj.lowlink == obj.num)
	{		disp= disp+1;
	       while(DetStrong.top().num >= obj.num)
		{			
			dispMap[disp].push_back(DetStrong.top().GetUserId());
			DetStrong.pop();
			if(DetStrong.size() == 0)
			break;
		}
	}
}



# endif