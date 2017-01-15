using Humanizer;
using Polly;
using System;
using System.Windows.Forms;

namespace TransientFaultHanlder
{
    public partial class HanlderForm : Form
    {
        #region : Internal :

        private Policy CircuitBreakerPolicy { get; }
        private PollySample _pollySample;
        private readonly Action<int, object> _logFunc;
        private int _retryCount;
        private TimeSpan _waitDuration ;


        public HanlderForm()
        {
            InitializeComponent();
            _logFunc = lstLog.Items.Insert;
            _pollySample = new PollySample(new EmailService(), Log);

            CircuitBreakerPolicy = _pollySample.DefineCircuitBreakerPolicy(3, 5.Seconds());
        }

        private void Run(Action func)
        {
            Cursor = Cursors.WaitCursor;
            _retryCount = Convert.ToInt32(txtRetryCount.Text);
            _waitDuration = Convert.ToDouble(txtWaitTime.Text).Seconds();
            LogSeparator("Started");

            func();

            LogSeparator("Completed");
            _logFunc(0, "");
            Cursor = Cursors.Default;
        }

        #region : Log :

        private int _logCounter;

        private void Log(string data)
        {
            _logCounter++;
            _logFunc(0, $"{_logCounter:0#}. [ {DateTime.Now:hh:mm:ss} ] - {data}");
            Application.DoEvents();
        }

        private readonly string _separatorChars = new string('*', 30);

        private void LogSeparator(string data)
        {
            _logFunc(0, $"{_separatorChars} {data} {_separatorChars}");
        }

        #endregion

        #endregion

        private void btnPollyRetry_Click(object sender, EventArgs e)
        {
            Run(() =>
                    _pollySample.Retry(_retryCount)
            );
        }

        private void btnPollyWaitRetry_Click(object sender, EventArgs e)
        {
            Run(() =>
                     _pollySample.WaitAndRetry(_retryCount, _waitDuration)
            );
        }

        private void btnPollyWaitRetryHandleResult_Click(object sender, EventArgs e)
        {
            Run(() =>
                    _pollySample.WaitAndRetry_Mocky(_retryCount, _waitDuration)
            );
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
            _logCounter = 0;
            _pollySample = new PollySample(new EmailService(), Log);
        }

        private void btnPollyWaitRetryDiff_Click(object sender, EventArgs e)
        {
            Run(() =>
                    _pollySample.WaitAndRetry_RandomWaitDurations(_retryCount)
            );
        }

        private void btnCircuitBreaker_Click(object sender, EventArgs e)
        {
            _pollySample.ExecuteCircuitBreaker(CircuitBreakerPolicy);
            //Run(() =>
            //            _pollySample.CircuitBreaker_Mocky(_retryCount, _waitDuration)
            //);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string data = @"تحديد التوجهات الأمنية و التنموية وصياغة الأهداف الاستراتيجية
        //            تعزيز إدارة الجانب الأمني والتنموي والخدمي من خلال الحوكمة و نظم إدارة المشاريع
        //            تطوير الخدمات للمواطنين والمقيمين
        //            تعزيز التواصل مع المواطنين و المقيمين و مؤسسات المجتمع المدني
        //            تعزيز التكامل وتبادل البيانات بين الأجهزة الحكومية
        //            رفع الكفاءة التشغيلية للإمارة
        //            إعداد القيادات وتطوير الكوادر البشرية ";

        //    var lst = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => $"<li><h2>{s.Trim()}</h2></li>");

        //    string data2 = $"<ol>{string.Join(Environment.NewLine, lst.ToArray())}</ol>";

        //    var t = ";;";

        //    //string data = @"
        //    //    استراتيجية تقنية المعلومات
        //    //    مرصد
        //    //    المناصب القبلية
        //    //    البيئة السحابية
        //    //    الخدمات الالكترونية
        //    //    نظام إدارة الموارد
        //    //    نظام متابعة المشاريع
        //    //    نظام إدارة مجلس المنطقة
        //    //    التوقيع الالكتروني
        //    //    الباب المفتوح
        //    //     تفعيل الهيكل التنظيمي المحدث لتقنية المعلومات
        //    //    انشاء مكتب هيكلية مؤسسية لريادة(EA Office establishment)
        //    //    تطوير إطار حوكمة وإدارة البيانات
        //    //    تطوير نظام أتمتة وسير العمل (WorkFlow engine)
        //    //    تطوير وتشغيل نظام إدارة المحافظ والمشاريع (إمكانية الاستفادة من نظام امارة المنطقة الشرقية)
        //    //    تطوير وتشغيل نظام الاتصالات الإدارية(قمم / ECM)
        //    //    تطوير وتشغيل نظام الأرشفة الإلكتروني(ECM)
        //    //    تطوير وتشغيل تنفيذ نظام إدارة عمليات تقنية المعلومات
        //    //    تطوير وتشغيل نظام إدارة علاقات العملاء (دعم دور مركز الخدمة الشامل)
        //    //    تطوير وتشغيل نظام إدارة الزيارات والفعاليات
        //    //    تطوير وتشغيل نظام التقارير الإحصائية والتحليلية (BI Reports, Analytics)
        //    //    تطوير وتشغيل نظام دعم عمليات صنع القرار(إدارة الاجتماعات)
        //    //    توفير تقنيات إدارة قنوات التواصل الاجتماعي(Social Media)
        //    //    تطوير وتشغيل نظام إدارة التخطيط وقياس الأداء المؤسسي
        //    //    تطوير وتشغيل نظام تخطيط الموارد المؤسسية
        //    //    تطبيق منصة التكامل والترابط
        //    //    تطوير البوابة الرئيسية الموحدة
        //    //    تطوير الخدمات الإلكترونية للإمارة - المجموعة الثانية
        //    //    تطوير الخدمات الإلكترونية للإمارة - المجموعة الثالثة
        //    //    تطوير الخدمات الإلكترونية للإمارة - المجموعة الرابعة
        //    //    تحسين حلول النسخ الاحتياطي
        //    //    تطبيق حلول أنظمة تحكم وإدارة الشبكة داخل المركز الرئيسي للإمارة
        //    //    تطبيق حلول أنظمة إدارة أمن الشبكة داخل المركز الرئيسي للإمارة
        //    //    تحسين شبكة المعلومات الواسعة في المركز الرئيسي للإمارة والاتصال مع الفروع وتحسين الاتصال بالإنترنت، وتطبيق الاتصال الافتراضي
        //    //    تطوير وتطبيق الاتصال بشبكة يسّر والجهات الحكومية الأخرى
        //    //    تقييم نواحي الضعف في أنظمة وشبكة الإمارة والقيام باختبار الاختراق
        //    //    تطبيق متطلبات التحسين التقنية لمركز البيانات لكل إمارة
        //    //    تطوير خطة لاستمرارية الأعمال وانشاء مركز بيانات رديف  لكل إمارة(او مجموعة امارات)";

        //    //var lst = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => $"<li>{s.Trim()}</li>");

        //    //string data2 = $"<ol>{string.Join(Environment.NewLine, lst.ToArray())}</ol>";
        //}
    }
}