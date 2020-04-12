import React from "react";
import { Menu, Icon } from "antd";
import { RouterData, router } from "../../Router";
import { Link } from "react-router-dom";

const SubMenu = Menu.SubMenu;

export default class SiderMenu extends React.Component {
  private menus: JSX.Element[] = [];

  // public componentDidMount() {
  //   // this.menus = this.getMenu();
  // }

  public render() {
    return (
      <Menu mode="inline" defaultSelectedKeys={['1']} style={{ border: 0 }}>
        {this.getMenu()}
      </Menu>
    );
  }

  private getSubMenu = (router: RouterData): JSX.Element => {
    return (
      <SubMenu key={router.key} title={
        <span>
          {router.icon ? (<Icon type={router.icon} />) : null}
          <span>{router.name}</span>
        </span>
      }>
        {
          router.children.map(item => {
            if (item.children.length === 0) {
              return (
                <Menu.Item key={item.key}>
                  <Link to={item.path} style={{ whiteSpace: 'normal' }}>{item.icon ? <Icon type={item.icon} /> : null}{item.name}</Link>
                </Menu.Item>
              );
            } else {
              return (this.getSubMenu(item));
            }
          })
        }
      </SubMenu>
    );
  }

  private getMenu = () => {
    let menus: JSX.Element[] = [];
    router.forEach(item => {
      if (item.children.length === 0) {
        menus.push((
          <Menu.Item key={item.key}>
            <Link to={item.path} style={{ whiteSpace: 'normal' }}>{item.icon ? <Icon type={item.icon} /> : null}{item.name}</Link>
          </Menu.Item>
        ));
      } else {
        menus.push(this.getSubMenu(item));
      }
    });

    return menus;
  }
}