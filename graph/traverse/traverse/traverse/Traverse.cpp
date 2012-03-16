/////////////////////////////////////////////////////////////////////
//  Traverse.h - Helps to traverse XML and determine dependencies  //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   XML Metadata Manager			                   //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////
#include "Traverse.h"
#include<string>
#include <algorithm>

static std::vector<stdStr> headervec;

// The depenfunc is a recursive function which initially determines the direct dependencies from the xml file inputted
// and later recursive call is made to the same function and the indirect dependencies are also determined.
void depenfunc(stdStr depenname)
{
	Container cc;
	static std::vector<std::string> vect;
	cc.SetKey(Convert::ToString(depenname));
	if(depenname!=Convert::ToStdStr("none"))
	{
	for (unsigned i=0;i<headervec.size();i++)
		{
			if(headervec[i] == depenname)
			{
			  
			  stdStr tempstd = headervec[i];
			  std::string temp = Convert::ToString(tempstd);
			  temp.append(".xml");
			  Parser::Parsing(temp);
			 }
		}
	}
	    vect = cc.GetVector();
		vector<std::string>::iterator it1;
		std::string keee = cc.GetKey();
		static std::vector<std::string> remover;
		remover.push_back(keee);
		cc.SetRVector(remover);
		for(unsigned i=0;i<remover.size();i++)
		{
		it1 = find(vect.begin(),vect.end(),remover[i]);
		if(it1!=vect.end())
		{
			vect.erase(it1);
		}
		}
		cc.SetVector(vect);
		if(vect.size()!=0)
		{
         for (unsigned it = 0;it<vect.size();it++)
		{
			
			depenfunc(Convert::ToStdStr(vect[it])); // the recursive call of the function
		}
		}
	}

// The functionremove function removes the packagename or the inputted file name from the dependency list. Since there can be no cyclic dependency
void functionremove()
{
	    Container c;
	    std::vector<std::string> indirectdep;
		indirectdep = c.GetRVector();
		vector<std::string>::iterator it1;
		it1 = find(indirectdep.begin(),indirectdep.end(),c.GetHfile()); // The c.GetHfile() gets the package name which is inputted or 
		if(it1!=indirectdep.end())                                      //the file to which direct and indirect dependencies are determined
		{
			indirectdep.erase(it1);
		}
		c.SetRVector(indirectdep);
}
// The main function gets the input from the command line
// 1. The path to be inputted
// 2. The package name for which direct and indirect dependencies are to be determined.
#ifdef TEST_TRAVESREINFO_H
int main(int argc, char* argv[])
	{
		Container c;
	   	stdStr directori = Convert::ToStdStr(argv[1]);
		Directory::SetCurrentDirectoryW(directori);
		std::cout<<Convert::ToString(Directory::GetCurrentDirectoryW());
		Directory::FileCollection(Convert::ToStdStr(argv[argc-1]));
		headervec = Directory::getxvector();
		stdStr final = Convert::ToStdStr(argv[2]);
		 std::string data = Convert::ToString(final);
        std::transform(data.begin(), data.end(), data.begin(), ::toupper);
	    stdStr packname = Convert::ToStdStr(data);
		c.Sethfile(Convert::ToString(packname));
		depenfunc(packname);
		std::vector<std::string> indirectdep;
		cout<<endl;
		cout<<c.GetHfile()<<" Direct and Indirect dependencies are "<<endl;
		cout<<"---------------------------------------------"<<endl;
		functionremove();
		indirectdep = c.GetRVector();
		for(unsigned i =0; i<indirectdep.size();i++)
		{
			cout<<indirectdep[i]<<endl;
		}
	
}
# endif