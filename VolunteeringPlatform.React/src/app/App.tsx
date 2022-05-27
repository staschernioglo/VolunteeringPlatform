import './App.css';
import { Route, Routes } from 'react-router-dom';
import { Layout } from 'widgets/layout';
import { Mainpage } from 'pages/Mainpage';
import { Projects } from 'pages/projects/projects';
import SignIn from 'pages/account/loginPage';
import { createContext, useEffect, useState } from 'react';
import authService from 'features/auth/authService';
import SignUp from 'pages/account/signUp';

const AuthContext = createContext<{ isLoggedIn: boolean; setLoggedStatus: (isLoggedIn: boolean) => void}>({ isLoggedIn: false, setLoggedStatus: () => {} });
export {AuthContext}

function App() {

  const [isLoggedIn, setLoggedStatus] = useState<boolean>(false);

  useEffect( ()=> {
    (authService.getCurrentUser()) ? setLoggedStatus(true) : setLoggedStatus(false);
  }, []);

  return (
    <>
    <AuthContext.Provider value={{isLoggedIn, setLoggedStatus}}>
    <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Mainpage />} />
          <Route path="projects" element={<Projects />} />
          <Route path="login" element={<SignIn />} />
          <Route path="signup" element={<SignUp />} />
          <Route path="*" element={<h1>ERROR 404</h1>} />
        </Route>
      </Routes>
    </AuthContext.Provider>
    </>
  );
}

export default App;
