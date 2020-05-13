using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDemo.Models
{
    public interface IOrdenamiento
    {
        List<Post> Ordenar(List<Post> posts);
    }
}
