import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import BaseLayout from './Components/Layouts/BaseLayout';
import Login from './Modules/Account/Login';
import './index.css';

ReactDOM.render(
  <BrowserRouter>
    <Switch>
      <Route path="/account/login" component={Login}/>
      <Route path="/" component={BaseLayout}/>
    </Switch>
  </BrowserRouter>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
