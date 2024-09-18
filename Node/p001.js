const express = require('express');
const mysql = require('mysql2');
const config = require('./config'); // Assuming configuration is stored in a separate file

const app = express();

// Create a MySQL connection
const connection = mysql.createConnection({
  host: config.host,
  user: config.user,
  password: config.password,
  database: config.database
});

app.get('/api/sql/user', (req, res) => {
  const id = req.query.id;
  
  const query = `SELECT * FROM Users WHERE Id = ${id}`;
  
  connection.query(query, (error, results) => {
    if (error) {
      return res.status(500).json({ error: 'Database error' });
    }
    
    if (results.length > 0) {
      const user = results[0];
      const returnString = `Name: ${user.Name}. Description: ${user.Description}`;
      res.send(returnString);
    } else {
      res.send('');
    }
  });
});

const port = 3000;
app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});