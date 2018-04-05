import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface Usser {
	id: number;
	name: string;
	age: number;
	mark: number;
	category: string;
}
interface UserListState {
	users: Usser[];
	loading: boolean;
}

export class FetchUsers extends React.Component<RouteComponentProps<{}>, UserListState>{
	constructor() {
		super();
		this.state = { users: [], loading: true };
		fetch('api/User').then(response => response.json() as Promise<Usser[]>)
			.then(data => {
				this.setState({
					users: data,
					loading: false,
				});
			});
	}
	
	public render() {
		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: FetchUsers.renderUserTable(this.state.users);
		return <div><h1>Users</h1>
			{contents}
			</div>
	}
	private static renderUserTable(users: Usser[]) {
		return <table className='table'>
			<thead>
				<tr>
					<th>id</th>
					<th>name</th>
					<th>age</th>
					<th>mark</th>
					<th>category</th>
				</tr>
			</thead>
			<tbody>
				{users.map(user =>
					<tr key={user.id}>
						<td>{user.name}</td>
						<td>{user.age}</td>
						<td>{user.mark}</td>
						<td>{user.category}</td>
					</tr>
				)}
			</tbody>
		</table>;
	}
}