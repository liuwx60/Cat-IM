import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import Loadable from 'react-loadable';

export interface RouterData {
  path: string,
  key: string,
  name: string,
  icon: string,
  isMenu: boolean,
  component: any,
  exact: boolean,
  children: RouterData[]
}

export const router: any[] = [
  {
    path: '/dashboard',
    key: 'Dashboard',
    name: 'Dashboard',
    icon: 'dashboard',
    isMenu: true,
    component: import('../Modules/Dashboard/Analysis'),
    exact: false,
    children: []
  },
  {
    path: '/system',
    key: 'System',
    name: '系统管理',
    icon: 'tool',
    isMenu: true,
    component: null,
    exact: false,
    children: [
      {
        path: '/system/admin/list',
        key: 'System.Admin.List',
        name: '管理员',
        icon: 'user',
        isMenu: true,
        component: import('../Modules/System/Admin/Admin'),
        exact: false,
        children: []
      }
    ]
  }
];

interface PrivateRouteProps {
  component: any;
  path: string;
}

const PrivateRoute = ({ component: Component, ...rest }: PrivateRouteProps) => (
  <Route
    {...rest}
    render={props =>
      localStorage.getItem("access_token") ? (
        <Component {...props}/>
      ) : (
        <Redirect
          to={{
            pathname: '/account/login',
            state: { from: props.location }
          }}
        />
      )}
  />
);

const getComponent = (component: Promise<any>) => {
  return Loadable({
    loader: () => component,
    loading: () => null
  });
};

const getRoute = (routers: RouterData[], routes: JSX.Element[]): JSX.Element[] => {
  routers.forEach(x => {
    if (x.children.length === 0) {
      routes.push(
        <PrivateRoute path={x.path} key={x.key} component={getComponent(x.component)} />
      );
      return;
    }

    getRoute(x.children, routes);
  });

  return routes;
};

export const routeData = getRoute(router, []);
