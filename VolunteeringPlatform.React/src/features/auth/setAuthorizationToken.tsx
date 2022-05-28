import axios from 'axios'

const setAuthorizationToken = (token: string | null) => {
  if(token){
    axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    console.log('Authorization is SET');
  } else {
    delete axios.defaults.headers.common['Authorization'];
    console.log('Authorization is Deleted');
  }
  
}

export default setAuthorizationToken