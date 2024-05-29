﻿using Data.Repositories.DiavanRepo;
using SWP391_Project.Data.Databases.DiavanSystem;
using SWP391_Project.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private BlogRepository _blogRepository;
        private CustomerRepository _customerRepository;
        private DiamondRepository _diamondRepository;
        private OrderRepository _orderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private ResultRepository _resultRepository;
        private ServiceDetailRepository _serviceDetailRepository;
        private ServiceRepository _serviceRepository;
        private UserRepository _userRepository;

        public UnitOfWork() { }

        public UnitOfWork(AppDbContext context, BlogRepository blogRepository, CustomerRepository customerRepository, DiamondRepository diamondRepository, OrderRepository orderRepository, OrderDetailRepository orderDetailRepository, 
            ResultRepository resultRepository, ServiceDetailRepository serviceDetailRepository, ServiceRepository serviceRepository, UserRepository userRepository)
        {
            _context = context;
            _blogRepository = blogRepository;
            _customerRepository = customerRepository;
            _diamondRepository = diamondRepository;
            _orderRepository = orderRepository;
            _serviceDetailRepository = serviceDetailRepository;
            _userRepository = userRepository;
            _orderDetailRepository = orderDetailRepository;
            _serviceRepository = serviceRepository;
            _resultRepository = resultRepository;
        }

        public BlogRepository BlogRepository
        {
            get
            {
                return _blogRepository ??= new Repositories.DiavanRepo.BlogRepository();
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ??= new Repositories.DiavanRepo.CustomerRepository();
            }
        }

        public DiamondRepository DiamondRepository
        {
            get
            {
                return _diamondRepository ??= new Repositories.DiavanRepo.DiamondRepository();
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new Repositories.DiavanRepo.OrderRepository();
            }
        }

        public OrderDetailRepository OrderDetailRepository
        {
            get
            {
                return _orderDetailRepository ??= new Repositories.DiavanRepo.OrderDetailRepository();
            }
        }

        public ResultRepository ResultRepository
        {
            get
            {
                return _resultRepository ??= new Repositories.DiavanRepo.ResultRepository();
            }
        }

        public ServiceDetailRepository ServiceDetailRepository
        {
            get
            {
                return _serviceDetailRepository ??= new Repositories.DiavanRepo.ServiceDetailRepository();
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new Repositories.DiavanRepo.UserRepository();
            }
        }

        public ServiceRepository ServiceRepository
        {
            get
            {
                return _serviceRepository ??= new Repositories.DiavanRepo.ServiceRepository();
            }
        }
    }
}