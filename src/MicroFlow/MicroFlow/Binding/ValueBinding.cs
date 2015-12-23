using JetBrains.Annotations;

namespace MicroFlow
{
    public sealed class ValueBinding<TProperty> : IPropertyBindingInfo
    {
        internal ValueBinding([NotNull] string propertyName, TProperty value)
        {
            PropertyName = propertyName.NotNullOrEmpty("propertyName");
            Value = value;
        }

        public string PropertyName { get; private set; }

        public PropertyBindingKind Kind
        {
            get {return PropertyBindingKind.Value;}
        }

        public TResult Analyze<TResult>(IBindingInfoAnalyzer<TResult> analyzer)
        {
            return analyzer.NotNull().AnalyzeValueBinding(this);
        }

        public TProperty Value { get; private set; }
    }
}