/////////////////////////////////////////////////////////////////
//  nav.cpp - recursively walk a directory tree starting at a  //
//  ver 1.9   specified path                                   //
//                                                             //
//  Language:      Visual C++, ver 8.0                         //
//  Platform:      Dell Precision T7400, Vista Ultimate, SP1   //
//  Application:   CSE775 Project #1, Spring 2009              //
//  Author:        Jim Fawcett, Syracuse University CST 4-187  //
//                 (315) 443-3948, jfawcett@twcny.rr.com       //
/////////////////////////////////////////////////////////////////

#include <iostream>     // standard output for test
#include <iomanip>      // output formatting
#include <vector>
#include "fileInfo.h"
#include "nav.h"
#include "wintools.h"
#include "conio.h"

using namespace std;
using namespace Win32Tools;

//----< default dir name display function >--------------------

void defProc::dirsProc(const stdStr& dir) 
{
  stdOut << TEXT("\n  ") << dir.c_str() << endl;
}

//----< default file data display function >-------------------

void defProc::
fileProc(const fileInfo& fi) 
{
  if(!fi.isDirectory())
    fi.showData(stdOut); 
}

//----< save user's working directory >------------------------

navig::navig(defProc &DP) : dp_(DP) 
{
// save user's working directory
  TCHAR buffer[PathBufferSize];
  GetCurrentDirectory( PathBufferSize, buffer);
  userDir_ = buffer;
}

//----< restore user's working directory >---------------------

navig::~navig() { SetCurrentDirectory(userDir_.c_str()); }

//----< walk directory tree rooted at dir >--------------------

void navig::walk(const stdStr& dir, const stdStr& fileMask) {

  stdStr path = Path::getFullPath(dir);
  dp_.dirsProc(path);
  std::vector<stdStr> dirs;
  std::vector<fileInfo> fis;
  fis = Directory::GetFileInfos(path,fileMask);
  for(size_t i=0; i<fis.size(); ++i)
  {
    dp_.fileProc(fis[i]);
  }

  dirs = Directory::GetDirectories(path,TEXT("*.*"));
  for(size_t i=0; i<dirs.size(); ++i)
    walk(dirs[i],fileMask);
}

//----< test stub >--------------------------------------------
//
//  - Recursively walk directory subtree pointed to
//    by the last command line argument.
//  - use default navig processing each time a directory
//    or file is encountered
//  - replace default processing with user defined processing
//    and repeat
//
#ifdef TEST_NAV

//----< wait for key press: requires conio >-------------------

void waitForKeyPress()
{
  std::cout << "\n  Press key to exit: ";
  getch();
}
void main(int argc, char *argv[]) {

  cout << "\n  Testing Directory Navigator "
       << "\n =============================\n";

  if(argc == 1) {
    cout << "\n  please enter starting path\n";
    waitForKeyPress();
    return;
  }

  try {
// create default processing object and start navigation

  cout << "\n  testing default dir/file processing: "
       << "\n --------------------------------------\n";

  stdOut << TEXT("\n  starting path = ") << fileInfo::getPath() << TEXT("\n");

  defProc dp;
  navig nav(dp);
  nav.walk(Convert::ToStdStr(argv[argc-1]),TEXT("*.*"));

  stdOut << TEXT("\n  ending path = ") << fileInfo::getPath() << TEXT("\n\n");

// User defined processing definded here.  Note that
// local classes can be defined as long as all members
// are inline.  Otherwise, just declare and define above
// main.
//
// These do nothing but prepend each output with some
// "-" characters to show that user defined processing
// is actually being used.  In a real application user 
// defined processing will certainly be quite different
// from the default
//
  class userProc : public defProc {

  public:
    virtual void fileProc(const fileInfo &fi) {
      fileInfo newfi = fi;
      newfi.showDate(false);
      newfi.showData(stdOut); 
    }
    virtual void dirsProc(const stdStr &dir) {
      stdOut << TEXT("\n  ") << dir.c_str() << endl;
    }
  };

// restart with user defined processing

  cout << "\n  testing modified dir/file processing: "
       << "\n ---------------------------------------\n";

  stdOut << TEXT("\n  starting path = ") << fileInfo::getPath() << TEXT("\n");

  userProc udp;
  navig newNav(udp);
  newNav.walk(Convert::ToStdStr(argv[argc-1]),"*.*");
  cout << "\n  ending path = " << newNav.getPath();
  cout << "\n\n";
  }
  catch(std::exception& ex)
  {
    cout << ex.what();
  }
  waitForKeyPress();
}

#endif
