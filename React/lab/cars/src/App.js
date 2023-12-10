import React,{Component} from 'react'
import './App.css';
import Docs from './header/Docs';
import Forum from './header/Forum';
import Tutorials from './header/Tutorials';
import Menu from './header/Menu';
import ErrorPage from './header/ErrorPage';
import Profile from './header/Profile';
import {BrowserRouter,Route,Switch,Redirect} from 'react-router-dom'


class App extends Component{
  
    constructor(props){
       super(props)

       this.state = {
         underConst:{
           Docs:false,
           Tutorials:true,
           Community:false
         }
       }
    }

  render(){
      
    return ( 
    <BrowserRouter>
        <Menu />

        <Switch>
           <Route exact path="/" component={Docs} />
           <Route path="/tutorials" component={Tutorials} /> 
           
           {/*
           <Route path="/tutorials" component={()=>(
              this.state.underConst.Tutorials ? (<Redirect to="/" />):(<Tutorials/>)
           )} />
           */}
           <Route path="/forum" component={Forum} />
           <Route path="/users/:profileId" component={Profile} />
           <Route component={ErrorPage} />
       </Switch> 
        
    </BrowserRouter>
  );
  }
  
}

export default App;
