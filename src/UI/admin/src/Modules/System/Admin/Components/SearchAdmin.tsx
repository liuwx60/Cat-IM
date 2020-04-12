import React from "react";
import { FormComponentProps } from "antd/lib/form";
import { Row, Col, Form, Input, Button } from "antd";

interface ISearchAdminProps extends FormComponentProps {
  onSubmit: (data: any) => void
}

class SearchAdmin extends React.Component<ISearchAdminProps, {}> {
  public render() {
    const { getFieldDecorator } = this.props.form;

    return (
      <Form className="search-form">
        <Row gutter={24}>
          <Col span={8}>
            <Form.Item label="用户名">
              {getFieldDecorator('username')(<Input />)}
            </Form.Item>
          </Col>
          <Col span={8}>
            <Form.Item label="昵称">
              {getFieldDecorator('nickname')(<Input />)}
            </Form.Item>
          </Col>
          <Col span={8}>
            <Form.Item>
              <Button type="primary" onClick={this.handleSubmit}>搜索</Button>
              <Button style={{ marginLeft: 8 }} onClick={this.handleReset}>重置</Button>
            </Form.Item>
          </Col>
        </Row>
      </Form>
    );
  }

  private handleReset = () => {
    this.props.form.resetFields();
  }

  private handleSubmit = () => {
    this.props.onSubmit(this.props.form.getFieldsValue());
  }
}

export default Form.create<ISearchAdminProps>()(SearchAdmin);
