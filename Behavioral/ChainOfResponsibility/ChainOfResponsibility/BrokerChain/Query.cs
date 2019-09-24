namespace ChainOfResponsibility.BrokerChain
{
    public class Query
    {
        public string CreatureName { get; set; }

        public int Result;

        public enum QueryType
        {
            Attack,Defence
        };

        public QueryType WhatToQuery;

        public Query(string creatureName,QueryType queryType,int value)
        {
            CreatureName = creatureName;
            WhatToQuery = queryType;
            Result = value;
        }
    }
}