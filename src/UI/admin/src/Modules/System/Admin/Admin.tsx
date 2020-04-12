import React from "react";
import { RouteComponentProps } from "react-router-dom";
import PageHeader from "../../../Components/Layouts/PageHeader";
import Main from "../../../Components/Layouts/Main";
import SearchAdmin from "./Components/SearchAdmin";
import { Table } from "antd";
import axios from "../../../Utils/Http";
import FetchAccountsInput from "./Models/FetchAccountsInput";

interface AdminState {
  fetchAccountsInput: FetchAccountsInput
}

export default class Admin extends React.Component<RouteComponentProps<{}>, AdminState> {

  public state = {
    fetchAccountsInput: {
      page: 1,
      pageSize: 20
    }
  }

  public render() {
    return (
      <div>
        <PageHeader {...this.props} title="管理员" />

        <Main>
          <SearchAdmin onSubmit={this.search} />
        </Main>

        <Main>
          <Table
            columns={[
              { title: 'Id', dataIndex: 'id' },
              { title: '用户名', dataIndex: 'username'}
            ]}
          />
        </Main>
      </div>
    );
  }

  public componentDidMount() {
    this.fetch();
  }

  private search = (data: any) => {
    console.log(data);
  }

  private fetch() {
    axios.get('account/fetch', {
      params: this.state.fetchAccountsInput
    }).then(result => {
      console.log(result);
    });
  }
}