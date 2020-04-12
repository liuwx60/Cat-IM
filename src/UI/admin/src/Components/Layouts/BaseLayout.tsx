import React from "react";
import { RouteComponentProps, Redirect, Switch } from "react-router-dom";
import { Layout, Menu, Icon, Badge, Dropdown, Avatar } from "antd";
import logo from '../../logo.svg';
import antdLogo from '../../Assets/svg/logo.svg';
import { routeData } from "../../Router";
import SiderMenu from "./SiderMenu";
import './BaseLayout.less';

const { Header, Sider, Content } = Layout;

interface BaseLayoutState {
  collapsed: boolean
}

export default class BaseLayout extends React.Component<RouteComponentProps<{}>, BaseLayoutState> {

  public state = {
    collapsed: false
  };

  public toggle = () => {
    // this.state.collapsed = !this.state.collapsed;
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  public render() {
    const menu = (
      <Menu>
        <Menu.Item>
          <Icon type="user" /> 个人中心
        </Menu.Item>
        <Menu.Item>
          <Icon type="setting" />设置
        </Menu.Item>
        <Menu.Divider />
        <Menu.Item key="logout">
          <Icon type="logout" />退出登录
        </Menu.Item>
      </Menu>
    );

    return (
      <Layout style={{ minHeight: '100%' }}>
        <Sider
          theme="light"
          trigger={null}
          collapsible={true}
          collapsed={this.state.collapsed}
          className="wx-antd-layout-sider"
        >
          <div className="sider-logo">
            <img src={antdLogo} alt="logo" />
            {this.state.collapsed ? null : (<span>REACT ADMIN</span>)}
          </div>
          <SiderMenu />
        </Sider>
        <Layout>
          <Header style={{ background: '#fff', padding: 0, zIndex: 99 }}>
            <div className="header-container">
              <div>
                <Icon
                  className="trigger"
                  type={this.state.collapsed ? 'menu-unfold' : 'menu-fold'}
                  onClick={this.toggle}
                />
              </div>
              <div className="header-action">
                <div>
                  <Badge count={5}>
                    <Icon type="bell" style={{ fontSize: '16px', padding: '4px' }} />
                  </Badge>
                </div>
                <div>
                  <Dropdown overlay={menu}>
                    <div className="user">
                      <Avatar src={logo} style={{ width: '24px', height: '24px' }} />
                      <span className="username">Guest</span>
                    </div>
                  </Dropdown>
                </div>
              </div>
            </div>
          </Header>

          <Content>
            <Switch>
              {routeData}
              <Redirect path="*" to="/dashboard" />
            </Switch>
          </Content>
        </Layout>
      </Layout>
    );
  }
}