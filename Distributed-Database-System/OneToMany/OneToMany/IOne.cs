using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneToMany
{
  public interface IOne
  {
    void SetResponce(string msg);
    bool AnotherCallback(string msg);
  }
}
