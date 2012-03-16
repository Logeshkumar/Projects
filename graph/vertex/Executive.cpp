/////////////////////////////////////////////////////////////////////
//  Executive.cpp - helps in excuting the various operations         //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   Dependency Graph Facility                       //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

#include "Executive.h"

//This is function which is used to get the
//files in the path inputted through the command line argument
void Exec::GetXmlFiles(std::string path,std::string filename)
{
	stdStr directori = Convert::ToStdStr(path);
	Directory::SetCurrentDirectoryW(directori);
	std::cout<<Convert::ToString(Directory::GetCurrentDirectoryW());
	Directory::FileCollection(Convert::ToStdStr(filename));
	
}
void Exec::CreateVertices(std::vector<stdStr> headervec)
{
	for (unsigned i=0;i<headervec.size();i++)
	  {	
			Vertex<std::string,std::string>  temp(Convert::ToString(headervec[i]));
			temp.storeVertex(temp);
	  }
}

void Exec::AddChildVertices(std::vector<Vertex<std::string,std::string>> ParentVert)
{
	Traverse t;
	Container c;
	graph<std::string,std::string> g;
	std::vector<Vertex<std::string,std::string>>::iterator parent;
	for(parent = ParentVert.begin(); parent!=ParentVert.end(); ++parent)
	  {
		     std::string tempo = (*parent).GetUserId();
		     t.depenfunc(Convert::ToStdStr(tempo));
			 std::vector<std::string> child =c.GetVector();
			 try
			 {
			 Vertex<std::string,std::string> Parent = g.getxmlObject(tempo);
			 for(unsigned j=0;j<child.size();j++)
		   {			
				 Vertex<std::string,std::string> V = g.getxmlObject(child[j]);
				 Parent.AddChild(V,c.GetTemp());			 			
		 	}
				 g.AddVertex(Parent);
				 c.vecClear();
		}
			 catch(exception& ex)
			 {
				 std::cout<<ex.what();
			 }
	}

}



#ifdef TEST_EXECUTIVE_H
int main(int argc, char* argv[])
{
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE); // Increasing the buffer size of Console window
    COORD dwsize;
    dwsize.X=5000;
    dwsize.Y=5000;
    SetConsoleScreenBufferSize(hConsole,dwsize);
	Exec e;                                           // Creating object for executive class
	string path = argv[1];
	string filename = argv[argc-1];
	e.GetXmlFiles(path,filename);                     // Getting the Xml files from the path inputted in command line
	std::vector<stdStr> headervec = Directory::getxvector();
	e.CreateVertices(headervec);                      // Creating the Vertices for the Xml files in the input path
	static std::vector<Vertex<std::string,std::string>> ParentVert = Vertex<std::string,std::string>::getstoredVector();
	e.AddChildVertices(ParentVert);                  // adding child vertices to the parents
	graph<std::string,std::string> g;
	std::cout<<std::endl<<"The depth for search"<<std::endl;
	g.DepthFSearch();                                // Doing Depth for search
	Global<std::string,std::string> glo;
	glo.SameVertex("ActionsandRules");               // Global Algorithm for Same vertice
	glo.SameEdge("\nD:\\ood2.2\\xml\\xml\\xml");     // Global Algorithm for same Edge
	Display<std::string,std::string> d;
	d.DisplayGlobalEdge(glo.GetGlobalMap());
	d.DisplayGraph();                                // Displaying the graph 
	g.StrongComponents();                            
	std::map<int,std::vector<std::string>> DispMap = g.GetMap();
	std::cout<<"The strong Componenets in the graph are"<<std::endl;
	d.DisplayStrongComp(DispMap);                   //Displaying the output for strong Components
	
}

# endif