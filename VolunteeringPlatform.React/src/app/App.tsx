import './App.css';
import { Route, Routes } from 'react-router-dom';
import { Layout } from 'widgets/layout';
import { Mainpage } from 'pages/Mainpage';
import { Projects } from 'pages/projects/projects';
import SignIn from 'pages/account/loginPage';
import { createContext, useEffect, useState } from 'react';
import authService from 'features/auth/authService';
import { getRole } from 'features/auth/roleDecoder';
import setAuthorizationToken from 'features/auth/setAuthorizationToken';
import RegistrationType from 'pages/account/signup/registrationType';
import RegisterOrganization from 'pages/account/signup/organizationRegistration';
import RegisterVolunteer from 'pages/account/signup/volunteerRegistration';
import RegisterSimpleUser from 'pages/account/signup/userRegistration';
import AddProject from 'pages/projects/add-project';
import AddGoodDeed from 'pages/gooddeeds/add-gooddeed';

const AuthContext = createContext<{ isLoggedIn: boolean; setLoggedStatus: (isLoggedIn: boolean) => void; role : string | null}>({ isLoggedIn: false, setLoggedStatus: () => {}, role: null });
export {AuthContext}

function App() {

  const [isLoggedIn, setLoggedStatus] = useState<boolean>(false);
  const [role, setRole] = useState<any>(null);

  useEffect( ()=> {
    (authService.getCurrentUser()) ? setLoggedStatus(true) : setLoggedStatus(false);
  }, []);

  useEffect( () => {
    setRole(getRole(authService.getCurrentUser()));
    console.log(authService.getCurrentUser());
    setAuthorizationToken(authService.getCurrentUser());
  }, [isLoggedIn])

  console.log("===========");
  console.log("Render");
  console.log("===========");
  console.log(role);
  console.log("===========");

  return (
    <>
    <AuthContext.Provider value={{isLoggedIn, setLoggedStatus, role}}>
    <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Mainpage />} />
          <Route path="projects" element={<Projects />} />
          <Route path="login" element={<SignIn />} />
          <Route path="signup" element={<RegistrationType />} />
          <Route path="signup/simple" element={<RegisterSimpleUser />} />
          <Route path="signup/volunteer" element={<RegisterVolunteer />} />
          <Route path="signup/organization" element={<RegisterOrganization />} />
          <Route path="addproject" element={<AddProject />} />
          <Route path="askforhelp" element={<AddGoodDeed />} />
          <Route path="*" element={<h1>ERROR 404</h1>} />
        </Route>
      </Routes>
    </AuthContext.Provider>
    </>
  );
}

export default App;
