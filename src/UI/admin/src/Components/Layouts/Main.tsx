import React from "react";
import { Card } from "antd";

export default class Main extends React.Component {
  public render() {
    return (
      <div style={{ padding: '24px 24px 0' }}>
        <Card bordered={false}>{this.props.children}</Card>
      </div>
    )
  }
}