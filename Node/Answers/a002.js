const express = require('express');
const app = express();

// Simulating a database context
const db = {
  findItems: (query) => {
    // Simulate database search
    return [{ name: 'Item 1' }, { name: 'Item 2' }];
  }
};

function sanitizeInput(input) {
  // In a real scenario, this would actually sanitize the input
  return input;
}

app.get('/api/search', (req, res) => {
  const query = req.query.query;
  const cleanQuery = sanitizeInput(query);

  const search = {
    query: sanitizeInput(query),
    items: []
  };

  try {
    search.items = db.findItems(cleanQuery);
    res.json(search);
  } catch (e) {
    res.status(500).json({ error: 'An error occurred during search' });
  }
});

const port = 3000;
app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});