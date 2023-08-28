using AutoMapper;
using Business.Abstract;
using Business.DTOs;
using DataAccess.Abstract.Visitor;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorDal _visitorDal;
        private readonly IMapper _mapper;


        public VisitorService(IVisitorDal visitorDal, IMapper mapper)
        {
            _visitorDal = visitorDal;
            _mapper = mapper;
        }

        public Task<int> AddVisitor(VisitorViewModel viewModel)
        {
           return _visitorDal.AddAsync(_mapper.Map<AppUser>(viewModel));
        }
    }
}
