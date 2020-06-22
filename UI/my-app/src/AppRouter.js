import React from 'react';
import {BrowserRouter as Router ,Route,Redirect} from 'react-router-dom'
import LoginView from './LogIn/LoginView'
import Home from './Home'
import "antd/dist/antd.css"
import './CSS/App.css'
export default AppRouter;
function AppRouter(){
 return(  <div>
     
         <Router>
         <Redirect to="/login" ></Redirect>
         <Route path="/login" component={LoginView}></Route>
         <Route path="/home" component={Home}></Route>
        </Router>
         </div>
       
        )
}
