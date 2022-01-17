/*
 * Created by SharpDevelop.
 * User: manue
 * Date: 07/09/2019
 * Time: 01:50 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Circulos3
{
	/// <summary>
	/// Description of Circle.
	/// </summary>
	public class Circle
	{
		Point p;
			int radio,id;
		
		public Circle(){
			
		}
		~Circle(){
		}
		
		public void AddCircle(int x, int y, int radio, int id){
			p.X=x;
			p.Y=y;
			this.radio=radio;
			this.id=id;
		}
		public int GetX(){
			return p.X;
		}
		public int GetY(){
			return p.Y;
		}
		public int GetRadio(){
			return radio;
		}
		public override string ToString()
		{
			return string.Format("[Circle Id={3}, X={0}, Y={1}, Radio={2} ]", p.X, p.Y, radio, id);
		}
		public void SetCircle(Circle para){
			this.p.X=para.p.X;
			this.p.Y=para.p.Y;
			this.radio=para.radio;
			this.id=para.id;
			
		}
		public int GetId(){
			return id;
		}
	}
}
