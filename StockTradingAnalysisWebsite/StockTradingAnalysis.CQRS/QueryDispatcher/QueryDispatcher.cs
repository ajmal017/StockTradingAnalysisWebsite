﻿using StockTradingAnalysis.Core.Common;
using StockTradingAnalysis.CQRS.Exceptions;
using StockTradingAnalysis.Interfaces.Queries;
using StockTradingAnalysis.Interfaces.Services.Core;

namespace StockTradingAnalysis.CQRS.QueryDispatcher
{
	/// <summary>
	/// The query dispatcher locates the correct query handler for a given query.
	/// </summary>
	/// <seealso cref="StockTradingAnalysis.Interfaces.Queries.IQueryDispatcher" />
	public class QueryDispatcher : IQueryDispatcher
	{
		/// <summary>
		/// The performance measurement service
		/// </summary>
		private readonly IPerformanceMeasurementService _performanceMeasurementService;

		/// <summary>
		/// Initializes this object
		/// </summary>
		/// <param name="performanceMeasurementService">The performance measurement service</param>
		public QueryDispatcher(IPerformanceMeasurementService performanceMeasurementService)
		{
			_performanceMeasurementService = performanceMeasurementService;
		}

		/// <summary>
		/// Delegates the specified query to a <see cref="IQueryHandler{TQuery,TResult}" /> implementation.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="query">The query.</param>
		/// <returns>The result generated by the <see cref="IQueryHandler{TQuery,TResult}" /></returns>
		public TResult Execute<TResult>(IQuery<TResult> query)
		{
			using (new TimeMeasure(ms => _performanceMeasurementService.CountQuery(ms)))
			{
				var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

				dynamic handler = DependencyResolver.Current.GetService(handlerType);

				if (handler == null)
					throw new QueryDispatcherException(handlerType);

				return handler.Execute((dynamic)query);
			}
		}
	}
}