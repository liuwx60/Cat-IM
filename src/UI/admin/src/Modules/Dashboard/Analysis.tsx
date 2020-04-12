import React from "react";
import Breadcrumb from "../../Components/Layouts/Breadcrumb";
import { RouteComponentProps } from "react-router-dom";

export default class Analysis extends React.Component<RouteComponentProps<{}>, {}> {
  public render() {
    return (
      <div>
        <Breadcrumb {...this.props} title="首页">
        </Breadcrumb>
      </div>
    )
  }
}