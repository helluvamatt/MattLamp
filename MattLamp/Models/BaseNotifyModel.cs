using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MattLamp.Models
{
    internal abstract class BaseNotifyModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool ChangeAndNotify<T>(ref T field, T value, Expression<Func<T>> memberExpression, Action<T, T> optionalCallback = null)
        {
            var body = GetExpressionBody(memberExpression);
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            T old = field;
            field = value;

            Notify(memberExpression);

            optionalCallback?.Invoke(old, field);

            return true;
        }

        protected bool Notify<T>(Expression<Func<T>> memberExpression)
        {
            var body = GetExpressionBody(memberExpression);
            var vmExpression = body.Expression as ConstantExpression;
            if (vmExpression != null)
            {
                LambdaExpression lambda = Expression.Lambda(vmExpression);
                Delegate vmFunc = lambda.Compile();
                object sender = vmFunc.DynamicInvoke();
                PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(body.Member.Name));
            }

            return true;
        }

        private MemberExpression GetExpressionBody<T>(Expression<Func<T>> memberExpression)
        {
            if (memberExpression == null)
            {
                throw new ArgumentNullException("memberExpression");
            }
            var body = memberExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Lambda must return a property.");
            }
            return body;
        }

        #endregion
    }
}
