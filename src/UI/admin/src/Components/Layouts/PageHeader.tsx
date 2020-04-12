import React from "react";
import { router as routerData } from "../../Router";
import { Breadcrumb, Icon } from "antd";
import { RouteComponentProps } from "react-router-dom";

interface IPageHeaderProps {
  title: string;
}

export default class PageHeader extends React.Component<RouteComponentProps<{}> & IPageHeaderProps, {}> {
  public render() {
    return (
      <div style={{ background: '#fff', padding: '16px 24px' }}>
        <Breadcrumb>{this.getBreadecrumb()}</Breadcrumb>
        <div style={{ marginTop: '8px' }}>
          <span style={{ color: 'rgba(0,0,0,.85)', fontWeight: 600, fontSize: '20px', lineHeight: '32px' }}>{this.props.title}</span>
        </div>
        <div>{this.props.children}</div>
      </div>
    );
  }

  private getBreadecrumb() {
    let breadcrumbs: JSX.Element[] = [];
    let router = routerData;

    while (router.length > 0) {
      let current = router.find(x => this.props.location.pathname.indexOf(x.path) === 0);
      if (!current) {
        break;
      }
      breadcrumbs.push(
        <Breadcrumb.Item key={current.key}>
          {current.icon ? <Icon type={current.icon} /> : null}
          <span>{current.name}</span>
        </Breadcrumb.Item>
      );

      router = current.children;
    }

    return breadcrumbs;
  }
}