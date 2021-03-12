using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMemberRepository memberRepository
            )
        {
            Members = memberRepository;
        }
        public IMemberRepository Members { get; }
    }
}
