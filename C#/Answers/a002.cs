/*
    The main error made by the programmer is that he returned the user supplied 'query' on row 27.
    This query will get returned to the client and, depending on both framwork used and payload,
    will result in an XSS. 
*/