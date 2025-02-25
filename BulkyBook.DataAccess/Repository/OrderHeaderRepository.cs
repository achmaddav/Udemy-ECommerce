﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

		public void UpdateStatus(int id, string orderStatus, string? paymentStaus = null)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(g => g.ID == id);
            if (orderFromDb != null) 
            {
                orderFromDb.OrderStatus = orderStatus;
                if (paymentStaus != null)
                {
                    orderFromDb.PaymentStatus = paymentStaus;
                }
            }
		}

		public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)  
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(g => g.ID == id);
			
            orderFromDb.SessionID = sessionId;
            orderFromDb.PaymentIntentID = paymentIntentId;
            orderFromDb.PaymentDate = DateTime.Now;
		} 
	}
}
