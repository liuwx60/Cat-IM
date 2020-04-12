import React from "react";
import { RouteComponentProps } from "react-router-dom";
import { router as routerData } from "../../Router";
import { Icon, Breadcrumb as AntdBreadcrumb } from "antd";

interface IBreadcrumbProps {
  title: string
}

export default class Breadcrumb extends React.Component<RouteComponentProps<{}> & IBreadcrumbProps, {}> {
  public shouldComponentUpdate(nextProps: any) {
    return nextProps.location !== this.props.location;
  }

  public render() {
    return (
      <div style={{ background: '#fff', padding: '16px 24px' }}>
        <AntdBreadcrumb>{this.getBreadecrumb()}</AntdBreadcrumb>
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
        <AntdBreadcrumb.Item key={current.key}>
          {current.icon ? <Icon type={current.icon} /> : null}
          <span>{current.name}</span>
        </AntdBreadcrumb.Item>
      );

      router = current.children;
    }

    return breadcrumbs;
  }
}