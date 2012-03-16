#include "Vertex.h"
int Getid::in=0;

int Getid::GetVal()
{
	return ++in;
}


#ifdef TEST_VERTEX_H
int main()
{
	Vertex<std::string,std::string> V1("v11");
	Vertex<std::string,std::string> V2("v22");
	Vertex<std::string,std::string> V3("v33");
	Vertex<std::string,std::string> V4("v44");
	Vertex<std::string,std::string> V5("v55");
	Vertex<std::string,std::string> V6("nodetop");
	Vertex<std::string,std::string> V7("nodetop");
	Vertex<std::string,std::string> V8("nodetop");
	Vertex<std::string,std::string> V9("nodeC");
	Vertex<std::string,std::string> V10("nodeD");
	Vertex<std::string,std::string> V11("nodeE");
	Vertex<std::string,std::string> V12("nodeF");
	V1.AddChild(V2,"E1");
	V2.AddChild(V3,"E1");
	V3.AddChild(V1,"E1");
	V3.AddChild(V4,"E1");
    V5.AddChild(V3,"E1");
	V4.AddChild(V5,"E1");
	V9.AddChild(V10,"E8");
	V9.AddChild(V11,"E8");
	V11.AddChild(V12,"E9");
	V6.AddChild(V1,"E10");
	V6.AddChild(V8,"E11");
	V6.AddChild(V7,"E12");
}
#endif